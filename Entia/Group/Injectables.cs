/* DO NOT MODIFY: The content of this file has been generated by the script 'Injectables.csx'. */

using Entia.Core;
using Entia.Dependables;
using Entia.Injectors;
using Entia.Modules;
using Entia.Modules.Group;
using Entia.Queryables;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Entia.Injectables
{
    public readonly struct Group<T> : IInjectable, IDepend<Dependables.Read<Entity>, T>, IEnumerable<T> where T : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T>(world.Groups().Get(world.Queriers().Get<T>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<T>[] Segments => _group.Segments;
        public Modules.Group.Group<T>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<T> _group;

        public Group(Modules.Group.Group<T> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out T item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<T>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<T>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2>, IEnumerable<All<T1, T2>> where T1 : struct, IQueryable where T2 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2>(world.Groups().Get(world.Queriers().Get<All<T1, T2>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2>> _group;

        public Group(Modules.Group.Group<All<T1, T2>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2>> IEnumerable<All<T1, T2>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3>, IEnumerable<All<T1, T2, T3>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3>> IEnumerable<All<T1, T2, T3>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4>, IEnumerable<All<T1, T2, T3, T4>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4>> IEnumerable<All<T1, T2, T3, T4>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4, T5> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4, T5>, IEnumerable<All<T1, T2, T3, T4, T5>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4, T5>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5>> IEnumerable<All<T1, T2, T3, T4, T5>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4, T5, T6> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4, T5, T6>, IEnumerable<All<T1, T2, T3, T4, T5, T6>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4, T5, T6>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6>> IEnumerable<All<T1, T2, T3, T4, T5, T6>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4, T5, T6, T7>, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4, T5, T6, T7>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7, T8> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4, T5, T6, T7, T8>, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable where T8 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7, T8>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7, T8>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4, T5, T6, T7, T8>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7, T8> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7, T8>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInjectable, IDepend<Dependables.Read<Entity>, T1, T2, T3, T4, T5, T6, T7, T8, T9>, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable where T8 : struct, IQueryable where T9 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7, T8, T9>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(member)));
        }

        [Injector]
        static readonly Injector _injector = new Injector();

        public int Count => _group.Count;
        public Segment<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>[] Segments => _group.Segments;
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> _group;

        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> group) { _group = group; }
        public bool Has(Entity entity) => _group.Has(entity);
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7, T8, T9> item) => _group.TryGet(entity, out item);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.SplitEnumerable Split(int count) => _group.Split(count);
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}