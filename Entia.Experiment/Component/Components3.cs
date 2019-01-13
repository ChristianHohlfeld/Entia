using Entia.Core;
using Entia.Experiment.Modules;
using Entia.Experiment.Resolvables;
using Entia.Messages;
using Entia.Modules.Component;
using Entia.Queryables;
using System;
using System.Collections.Generic;

namespace Entia.Modules
{
    public sealed class Components3 : IModule, IResolvable
    {
        struct Data
        {
            public Segment Segment;
            public int Index;
            public int? Transient;
        }

        public ArrayEnumerable<Segment> Segments => _segments.Enumerate();

        readonly Transient _transient = new Transient();
        readonly Messages _messages;
        readonly Segment _created = new Segment(int.MaxValue, new BitMask());
        readonly Segment _destroyed = new Segment(int.MaxValue, new BitMask(), 1);
        readonly Segment _empty = new Segment(0, new BitMask());
        readonly Dictionary<BitMask, Segment> _maskToSegment;
        (Data[] items, int count) _data = (new Data[64], 0);
        (Segment[] items, int count) _segments;

        public Components3(Messages messages)
        {
            _messages = messages;
            // NOTE: do not include '_pending' here
            _segments = (new Segment[] { _empty }, 1);
            _maskToSegment = new Dictionary<BitMask, Segment> { { _empty.Mask, _empty } };
            _messages.React((in OnCreate message) => Initialize(message.Entity));
            _messages.React((in OnPreDestroy message) => Dispose(message.Entity));
        }

        public ref T Get<T>(Entity entity) where T : struct, IComponent
        {
            if (TryGetStore<T>(entity, out var store, out var adjusted)) return ref store[adjusted];
            if (_messages.Has<OnException>()) _messages.Emit(new OnException { Exception = ExceptionUtility.MissingComponent(entity, typeof(T)) });
            return ref Dummy<T>.Value;
        }

        public ref T GetOrDummy<T>(Entity entity, out bool success) where T : struct, IComponent
        {
            if (TryGetStore<T>(entity, out var store, out var adjusted))
            {
                success = true;
                return ref store[adjusted];
            }

            success = false;
            return ref Dummy<T>.Value;
        }

        public ref T GetOrAdd<T>(Entity entity, Func<T> create = null) where T : struct, IComponent
        {
            if (TryGetStore<T>(entity, out var store, out var adjusted)) return ref store[adjusted];
            Set(entity, create?.Invoke() ?? default);
            return ref Get<T>(entity);
        }

        public bool TryGet<T>(Entity entity, out T component) where T : struct, IComponent
        {
            component = GetOrDummy<T>(entity, out var success);
            return success;
        }

        public bool TryGet(Entity entity, Type type, out IComponent component)
        {
            if (TryGetStore(entity, type, out var store, out var index))
            {
                component = (IComponent)store.GetValue(index);
                return true;
            }

            component = default;
            return false;
        }

        public IComponent Get(Entity entity, Type type)
        {
            if (TryGet(entity, type, out var component)) return component;
            if (_messages.Has<OnException>()) _messages.Emit(new OnException { Exception = ExceptionUtility.MissingComponent(entity, type) });
            return null;
        }

        public IEnumerable<IComponent> Get(Entity entity)
        {
            if (TryGetData(entity, out var data))
            {
                var segment = GetTargetSegment(data);
                var types = segment.Types.data;
                for (int i = 0; i < types.Length; i++)
                {
                    if (TryGetStore(data, types[i], out var store, out var index))
                        yield return (IComponent)store.GetValue(index);
                }
            }
        }

        public bool Has<T>(Entity entity) where T : struct, IComponent => Has(entity, ComponentUtility.Cache<T>.Data.Index);
        public bool Has(Entity entity, Type component) => ComponentUtility.TryGetMetadata(component, out var data) && Has(entity, data.Index);

        public bool Set<T>(Entity entity, in T component) where T : struct, IComponent
        {
            ref var data = ref GetData(entity, out var success);
            if (success)
            {
                var metadata = ComponentUtility.Cache<T>.Data;
                if (data.Segment.TryStore<T>(out var store))
                {
                    store[data.Index] = component;
                    return data.Transient is int transient && _transient.Slots.items[transient].Mask.Add(metadata.Index);
                }

                ref var slot = ref GetTransientSlot(entity, ref data);
                if (slot.Resolution == Transient.Resolutions.Remove) return false;

                var index = data.Transient.Value;
                store = _transient.Store<T>(index, out var adjusted);
                store[adjusted] = component;
                return slot.Mask.Add(metadata.Index);
            }

            return false;
        }

        public bool Remove<T>(Entity entity) where T : struct, IComponent
        {
            ref var data = ref GetData(entity, out var success);
            var metadata = ComponentUtility.Cache<T>.Data;
            if (success && Has(data, metadata.Index))
            {
                ref var slot = ref GetTransientSlot(entity, ref data);
                return slot.Mask.Remove(metadata.Index);
            }

            return false;
        }

        public bool Clear(Entity entity)
        {
            ref var data = ref GetData(entity, out var success);
            if (success && data.Segment != _empty)
            {
                ref var slot = ref GetTransientSlot(entity, ref data);
                return slot.Mask.Clear();
            }

            return false;
        }

        public void Resolve()
        {
            for (int i = 0; i < _transient.Slots.count; i++)
            {
                ref var slot = ref _transient.Slots.items[i];
                ref var data = ref GetData(slot.Entity, out var success);

                if (success)
                {
                    switch (slot.Resolution)
                    {
                        case Transient.Resolutions.Add:
                            {
                                var segment = GetSegment(slot.Mask);
                                CopyTo((data.Segment, data.Index), (segment, segment.Entities.count++));
                                break;
                            }
                        case Transient.Resolutions.Remove:
                            {
                                MoveTo((data.Segment, data.Index), _destroyed);
                                _destroyed.Entities.count = 0;
                                data = default;
                                break;
                            }
                        default:
                            {
                                var segment = GetSegment(slot.Mask);
                                MoveTo((data.Segment, data.Index), segment);
                                break;
                            }
                    }
                }

                data.Transient = default;
            }

            _created.Entities.count = 0;
            _destroyed.Entities.count = 0;
            _transient.Slots.count = 0;
        }

        public bool TryGetStore<T>(Entity entity, out T[] store, out int index) where T : struct, IComponent
        {
            if (TryGetData(entity, out var data) && TryGetStore<T>(data, out store, out index)) return true;
            store = default;
            index = default;
            return false;
        }

        public bool TryGetStore(Entity entity, Type type, out Array store, out int index)
        {
            if (TryGetData(entity, out var data) &&
                ComponentUtility.TryGetMetadata(type, out var metadata) &&
                TryGetStore(data, metadata, out store, out index))
                return true;

            store = default;
            index = default;
            return false;
        }

        public bool TryGetSegment(Entity entity, out (Segment segment, int index) pair)
        {
            if (TryGetData(entity, out var data))
            {
                pair = (data.Segment, data.Index);
                return true;
            }

            pair = default;
            return false;
        }

        ref Data GetData(Entity entity, out bool success)
        {
            if (entity.Index < _data.count)
            {
                ref var data = ref _data.items[entity.Index];
                if (data.Segment is Segment segment)
                {
                    ref var entities = ref data.Segment.Entities;
                    // NOTE: use 'entities.items.Length' rather than 'entities.count' to include newly created entities
                    success = data.Index < entities.items.Length && entities.items[data.Index] == entity;
                    return ref data;
                }
            }

            success = false;
            return ref Dummy<Data>.Value;
        }

        bool TryGetData(Entity entity, out Data data)
        {
            data = GetData(entity, out var success);
            return success;
        }

        bool TryGetStore<T>(in Data data, out T[] store, out int adjusted) where T : struct, IComponent
        {
            if (TryGetStore(data, ComponentUtility.Cache<T>.Data, out var array, out adjusted))
            {
                store = array as T[];
                return store != null;
            }

            store = default;
            return false;
        }

        bool TryGetStore(in Data data, in Metadata metadata, out Array store, out int adjusted)
        {
            adjusted = data.Index;
            data.Segment.TryStore(metadata, out store);

            if (data.Transient is int transient)
            {
                // NOTE: prioritize the segment store
                store = store ?? _transient.Store(transient, metadata, out adjusted);
                ref readonly var slot = ref _transient.Slots.items[transient];
                return Has(slot, metadata.Index);
            }

            return store != null;
        }

        int MoveTo(in (Segment segment, int index) source, Segment target)
        {
            if (source.segment == target) return source.index;

            var index = target.Entities.count++;
            CopyTo(source, (target, index));
            // NOTE: copy the last entity to the moved entity's slot
            CopyTo((source.segment, --source.segment.Entities.count), source);
            return index;
        }

        bool CopyTo(in (Segment segment, int index) source, in (Segment segment, int index) target)
        {
            if (source == target) return false;

            ref var entity = ref source.segment.Entities.items[source.index];
            target.segment.Entities.Set(target.index, entity);
            ref var data = ref _data.items[entity.Index];

            var types = target.segment.Types.data;
            for (int i = 0; i < types.Length; i++)
            {
                ref readonly var metadata = ref types[i];
                ref var targetStore = ref target.segment.Store(metadata.Index);
                ArrayUtility.Ensure(ref targetStore, metadata.Type, target.segment.Entities.items.Length);

                if (TryGetStore(data, metadata, out var sourceStore, out var sourceIndex))
                    Array.Copy(sourceStore, sourceIndex, targetStore, target.index, 1);
            }

            var message = new Entia.Messages.Segment.OnMove { Entity = entity, Source = source, Target = target };
            data.Segment = target.segment;
            data.Index = target.index;
            entity = default;
            _messages.Emit(message);
            return true;
        }

        bool Has(Entity entity, int component)
        {
            ref var data = ref GetData(entity, out var success);
            return success && Has(data, component);
        }

        bool Has(in Data data, int component)
        {
            if (data.Transient is int transient)
            {
                ref readonly var slot = ref _transient.Slots.items[transient];
                return Has(slot, component);
            }
            return data.Segment.Has(component);
        }

        bool Has(in Transient.Slot slot, int component) => slot.Resolution != Transient.Resolutions.Remove && slot.Mask.Has(component);

        void Initialize(Entity entity)
        {
            var transient = _transient.Reserve(entity, Transient.Resolutions.Add);
            var segment = _created;
            var index = segment.Entities.count++;
            segment.Entities.Ensure();
            segment.Entities.items[index] = entity;
            _data.Set(entity.Index, new Data { Segment = segment, Index = index, Transient = transient });
        }

        void Dispose(Entity entity)
        {
            ref var data = ref GetData(entity, out var success);
            if (success)
            {
                ref var slot = ref GetTransientSlot(entity, ref data);
                slot.Resolution = Transient.Resolutions.Remove;
                slot.Mask.Clear();
            }
        }

        Segment GetTargetSegment(in Data data) => data.Transient is int transient ? GetSegment(_transient.Slots.items[transient].Mask) : data.Segment;

        ref Transient.Slot GetTransientSlot(Entity entity, ref Data data)
        {
            var index = data.Transient ?? _transient.Reserve(entity, Transient.Resolutions.Move, data.Segment.Mask);
            data.Transient = index;
            return ref _transient.Slots.items[index];
        }

        Segment GetSegment(BitMask mask)
        {
            if (_maskToSegment.TryGetValue(mask, out var segment)) return segment;
            var clone = new BitMask { mask };
            segment = _maskToSegment[clone] = _segments.Push(new Segment(_segments.count, clone));
            _messages.Emit(new Entia.Messages.Segment.OnCreate { Segment = segment });
            return segment;
        }
    }
}