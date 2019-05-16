using Entia.Components;
using Entia.Core;
using Entia.Core.Documentation;
using Entia.Messages;
using Entia.Modules.Component;
using Entia.Modules.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Entia.Modules
{
    /// <summary>
    /// Module that stores and manages components.
    /// </summary>
    public sealed partial class Components : IModule, IResolvable, IEnumerable<IComponent>
    {
        /// <summary>
        /// Tries to get the component store of type <typeparamref name="T"/> associated with the <paramref name="entity"/>.
        /// </summary>
        /// <typeparam name="T">The concrete component type.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="store">The store.</param>
        /// <param name="index">The index in the store where the component is.</param>
        /// <param name="include">A filter that includes only the components that correspond to the provided states.</param>
        /// <returns>Returns <c>true</c> if the store was found; otherwise, <c>false</c>.</returns>
        [ThreadSafe]
        public bool TryStore<T>(Entity entity, out T[] store, out int index, States include = States.All) where T : struct, IComponent
        {
            ref readonly var data = ref GetData(entity, out var success);
            if (success && TryGetStore(data, include, out store, out index)) return true;
            store = default;
            index = default;
            return false;
        }

        /// <summary>
        /// Tries to get the component store of provided <paramref name="type"/> associated with the <paramref name="entity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="type">The concrete component type.</param>
        /// <param name="store">The store.</param>
        /// <param name="index">The index in the store where the component is.</param>
        /// <param name="include">A filter that includes only the components that correspond to the provided states.</param>
        /// <returns>Returns <c>true</c> if the store was found; otherwise, <c>false</c>.</returns>
        [ThreadSafe]
        public bool TryStore(Entity entity, Type type, out Array store, out int index, States include = States.All)
        {
            if (TryGetData(entity, out var data) &&
                ComponentUtility.TryGetMetadata(type, out var metadata) &&
                TryGetStore(data, metadata, include, out store, out index))
                return true;

            store = default;
            index = default;
            return false;
        }

        [ThreadSafe]
        bool TryGetStore<T>(in Data data, States include, out T[] store, out int adjusted) where T : struct, IComponent
        {
            if (TryGetStore(data, ComponentUtility.Concrete<T>.Data, include, out var array, out adjusted))
            {
                store = array as T[];
                return store != null;
            }

            store = default;
            return false;
        }

        [ThreadSafe]
        bool TryGetStore(in Data data, in Metadata metadata, States include, out Array store, out int adjusted)
        {
            adjusted = data.Index;
            data.Segment.TryStore(metadata.Index, out store);

            if (data.Transient is int transient)
            {
                // NOTE: prioritize the segment store
                if (store == null) _transient.TryStore(transient, metadata, out store, out adjusted);
                ref readonly var slot = ref _transient.Slots.items[transient];
                // NOTE: if the slot has the component, then the store must not be null
                return Has(slot, metadata.Index, include);
            }

            return store != null;
        }

        bool GetStore(ref Data data, in Metadata metadata, out Array store, out int adjusted)
        {
            adjusted = data.Index;
            if (data.Segment.TryStore(metadata.Index, out store)) return true;

            if (data.Transient is int transient)
            {
                // NOTE: prioritize the segment store
                store = _transient.Store(transient, metadata, out adjusted);
                return true;
            }

            return false;
        }

        bool GetStore<T>(ref Data data, out T[] store, out int adjusted) where T : struct, IComponent
        {
            adjusted = data.Index;
            if (data.Segment.TryStore<T>(out store)) return true;

            if (data.Transient is int transient)
            {
                // NOTE: prioritize the segment store
                store = _transient.Store<T>(transient, out adjusted);
                return true;
            }

            return false;
        }
    }
}