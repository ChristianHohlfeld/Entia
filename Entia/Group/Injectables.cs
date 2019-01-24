/* DO NOT MODIFY: The content of this file has been generated by the script 'Injectables.csx'. */

using Entia.Core;
using Entia.Core.Documentation;
using Entia.Dependables;
using Entia.Dependencies;
using Entia.Dependers;
using Entia.Injectors;
using Entia.Modules;
using Entia.Modules.Group;
using Entia.Queryables;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Entia.Injectables
{
    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T> : IInjectable, IEnumerable<T> where T : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T>(world.Groups().Get(world.Queriers().Get<T>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<T>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<T>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<T>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<T> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<T> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out T item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<T>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<T>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2> : IInjectable, IEnumerable<All<T1, T2>> where T1 : struct, IQueryable where T2 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2>(world.Groups().Get(world.Queriers().Get<All<T1, T2>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2>> IEnumerable<All<T1, T2>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3> : IInjectable, IEnumerable<All<T1, T2, T3>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3>> IEnumerable<All<T1, T2, T3>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4> : IInjectable, IEnumerable<All<T1, T2, T3, T4>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4>> IEnumerable<All<T1, T2, T3, T4>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4, T5> : IInjectable, IEnumerable<All<T1, T2, T3, T4, T5>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4, T5>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4, T5>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4, T5}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5>> IEnumerable<All<T1, T2, T3, T4, T5>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4, T5, T6> : IInjectable, IEnumerable<All<T1, T2, T3, T4, T5, T6>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4, T5, T6>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4, T5, T6>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4, T5, T6}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6>> IEnumerable<All<T1, T2, T3, T4, T5, T6>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7> : IInjectable, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4, T5, T6, T7>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4, T5, T6, T7>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4, T5, T6, T7}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7, T8> : IInjectable, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable where T8 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7, T8>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7, T8>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4, T5, T6, T7, T8>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4, T5, T6, T7, T8>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4, T5, T6, T7, T8}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7, T8> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7, T8>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Gives access to group operations.
    /// </summary>
    [ThreadSafe]
    public readonly struct Group<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInjectable, IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable where T8 : struct, IQueryable where T9 : struct, IQueryable
    {
        sealed class Injector : IInjector
        {
            public Result<object> Inject(MemberInfo member, World world) => new Group<T1, T2, T3, T4, T5, T6, T7, T8, T9>(world.Groups().Get(world.Queriers().Get<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(member)));
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                foreach (var dependency in world.Dependers().Dependencies<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        /// <inheritdoc cref="Modules.Group.Group{T}.Count"/>
        public int Count => _group.Count;
        /// <inheritdoc cref="Modules.Group.Group{T}.Segments"/>
        public Segment<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>[] Segments => _group.Segments;
        /// <inheritdoc cref="Modules.Group.Group{T}.Entities"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.EntityEnumerable Entities => _group.Entities;

        readonly Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> _group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> struct.
        /// </summary>
        /// <param name="group">The group.</param>
        public Group(Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> group) { _group = group; }
        /// <inheritdoc cref="Modules.Group.Group{T}.Has(Entity)"/>
        public bool Has(Entity entity) => _group.Has(entity);
        /// <inheritdoc cref="Modules.Group.Group{T}.TryGet(Entity, out T)"/>
        public bool TryGet(Entity entity, out All<T1, T2, T3, T4, T5, T6, T7, T8, T9> item) => _group.TryGet(entity, out item);
        /// <inheritdoc cref="Modules.Group.Group{T}.Split(int)"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.SplitEnumerable Split(int count) => _group.Split(count);
        /// <inheritdoc cref="Modules.Group.Group{T}.GetEnumerator"/>
        public Modules.Group.Group<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.Enumerator GetEnumerator() => _group.GetEnumerator();
        IEnumerator<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>> IEnumerable<All<T1, T2, T3, T4, T5, T6, T7, T8, T9>>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}