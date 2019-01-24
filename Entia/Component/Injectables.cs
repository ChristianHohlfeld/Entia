﻿using Entia.Core;
using Entia.Dependencies;
using Entia.Dependers;
using Entia.Injectors;
using Entia.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Entia.Injectables
{
    /// <summary>
    /// Gives access to all component operations.
    /// </summary>
    public readonly struct AllComponents : IInjectable, IEnumerable<IComponent>
    {
        sealed class Injector : Injector<AllComponents>
        {
            public override Result<AllComponents> Inject(MemberInfo member, World world) => new AllComponents(world.Components());
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                yield return new Dependencies.Write(typeof(IComponent));
                yield return new Dependencies.Emit(typeof(Messages.OnAdd));
                yield return new Dependencies.Emit(typeof(Messages.OnAdd<>));
                yield return new Dependencies.Emit(typeof(Messages.OnRemove));
                yield return new Dependencies.Emit(typeof(Messages.OnRemove<>));
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        readonly Components _components;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllComponents"/> struct.
        /// </summary>
        /// <param name="components"></param>
        public AllComponents(Components components) { _components = components; }

        /// <inheritdoc cref="Components.Get{T}(Entity)"/>
        [ThreadSafe]
        public ref T Get<T>(Entity entity) where T : struct, IComponent => ref _components.Get<T>(entity);
        /// <inheritdoc cref="Components.GetOrAdd{T}(Entity, Func{T})"/>
        public ref T GetOrAdd<T>(Entity entity, Func<T> create = null) where T : struct, IComponent => ref _components.GetOrAdd(entity, create);
        /// <inheritdoc cref="Components.GetOrDummy{T}(Entity, out bool)"/>
        [ThreadSafe]
        public ref T GetOrDummy<T>(Entity entity, out bool success) where T : struct, IComponent => ref _components.GetOrDummy<T>(entity, out success);
        /// <inheritdoc cref="Components.TryGet{T}(Entity, out T)"/>
        [ThreadSafe]
        public bool TryGet<T>(Entity entity, out T component) where T : struct, IComponent => _components.TryGet(entity, out component);
        /// <inheritdoc cref="Components.TryGet(Entity, Type, out IComponent)"/>
        [ThreadSafe]
        public bool TryGet(Entity entity, Type type, out IComponent component) => _components.TryGet(entity, type, out component);
        /// <inheritdoc cref="Components.Get(Entity)"/>
        public IEnumerable<IComponent> Get(Entity entity) => _components.Get(entity);
        /// <inheritdoc cref="Components.Get{T}()"/>
        [ThreadSafe]
        public IEnumerable<(Entity entity, T component)> Get<T>() where T : struct, IComponent => _components.Get<T>();
        /// <inheritdoc cref="Components.Get(Type)"/>
        [ThreadSafe]
        public IEnumerable<(Entity entity, IComponent component)> Get(Type type) => _components.Get(type);
        /// <inheritdoc cref="Components.Set{T}(Entity, in T)"/>
        public bool Set<T>(Entity entity, in T component) where T : struct, IComponent => _components.Set(entity, component);
        /// <inheritdoc cref="Components.Set(Entity, IComponent)"/>
        public bool Set(Entity entity, IComponent component) => _components.Set(entity, component);
        /// <inheritdoc cref="Components.Has{T}(Entity)"/>
        [ThreadSafe]
        public bool Has<T>(Entity entity) where T : struct, IComponent => _components.Has<T>(entity);
        /// <inheritdoc cref="Components.Has(Entity, Type)"/>
        [ThreadSafe]
        public bool Has(Entity entity, Type type) => _components.Has(entity, type);
        /// <inheritdoc cref="Components.Remove{T}(Entity)"/>
        public bool Remove<T>(Entity entity) where T : struct, IComponent => _components.Remove<T>(entity);
        /// <inheritdoc cref="Components.Remove(Entity, Type)"/>
        public bool Remove(Entity entity, Type type) => _components.Remove(entity, type);
        /// <inheritdoc cref="Components.Clear{T}()"/>
        public bool Clear<T>() where T : struct, IComponent => _components.Clear<T>();
        /// <inheritdoc cref="Components.Clear(Type)"/>
        public bool Clear(Type type) => _components.Clear(type);
        /// <inheritdoc cref="Components.Clear(Entity)"/>
        public bool Clear(Entity entity) => _components.Clear(entity);
        /// <inheritdoc cref="Components.Clear()"/>
        public bool Clear() => _components.Clear();
        /// <inheritdoc cref="Components.GetEnumerator()"/>
        public IEnumerator<IComponent> GetEnumerator() => _components.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _components.GetEnumerator();
    }

    /// <summary>
    /// Gives access to component operations for type <typeparamref name="T"/>.
    /// </summary>
    public readonly struct Components<T> : IInjectable, IEnumerable<(Entity entity, T component)> where T : struct, IComponent
    {
        /// <inheritdoc cref="Components{T}"/>
        [ThreadSafe]
        public readonly struct Write : IInjectable, IEnumerable<(Entity entity, T component)>
        {
            sealed class Injector : Injector<Write>
            {
                public override Result<Write> Inject(MemberInfo member, World world) => new Write(world.Components());
            }

            sealed class Depender : IDepender
            {
                public IEnumerable<IDependency> Depend(MemberInfo member, World world)
                {
                    yield return new Dependencies.Read(typeof(Entity));
                    yield return new Dependencies.Write(typeof(T));
                    foreach (var dependency in world.Dependers().Dependencies<T>()) yield return dependency;
                }
            }

            [Injector]
            static readonly Injector _injector = new Injector();
            [Depender]
            static readonly Depender _depender = new Depender();

            readonly Components _components;

            /// <summary>
            /// Initializes a new instance of the <see cref="Components{T}.Write" /> struct.
            /// </summary>
            /// <param name="components"></param>
            public Write(Components components) { _components = components; }

            /// <inheritdoc cref="Components.GetOrDummy{T}(Entity, out bool)"/>
            public ref T GetOrDummy(Entity entity, out bool success) => ref _components.GetOrDummy<T>(entity, out success);
            /// <inheritdoc cref="Components.TryGet{T}(Entity, out T)"/>
            public bool TryGet(Entity entity, out T component) => _components.TryGet(entity, out component);
            /// <inheritdoc cref="Components.Get{T}(Entity)"/>
            public ref T Get(Entity entity) => ref _components.Get<T>(entity);
            /// <inheritdoc cref="Components.Has{T}(Entity)"/>
            public bool Has(Entity entity) => _components.Has<T>(entity);
            /// <inheritdoc cref="Components.GetEnumerator()"/>
            public IEnumerator<(Entity entity, T component)> GetEnumerator() => _components.Get<T>().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <inheritdoc cref="Components{T}"/>
        [ThreadSafe]
        public readonly struct Read : IInjectable, IEnumerable<(Entity entity, T component)>
        {
            sealed class Injector : Injector<Read>
            {
                public override Result<Read> Inject(MemberInfo member, World world) => new Read(world.Components());
            }

            sealed class Depender : IDepender
            {
                public IEnumerable<IDependency> Depend(MemberInfo member, World world)
                {
                    yield return new Dependencies.Read(typeof(Entity));
                    yield return new Dependencies.Read(typeof(T));
                    foreach (var dependency in world.Dependers().Dependencies<T>()) yield return dependency;
                }
            }

            [Injector]
            static readonly Injector _injector = new Injector();
            [Depender]
            static readonly Depender _depender = new Depender();

            readonly Components _components;

            /// <summary>
            /// Initializes a new instance of the <see cref="Components{T}.Read" /> struct.
            /// </summary>
            /// <param name="components"></param>
            public Read(Components components) { _components = components; }

            /// <inheritdoc cref="Components.GetOrDummy{T}(Entity, out bool)"/>
            public ref readonly T GetOrDummy(Entity entity, out bool success) => ref _components.GetOrDummy<T>(entity, out success);
            /// <inheritdoc cref="Components.TryGet{T}(Entity, out T)"/>
            public bool TryGet(Entity entity, out T component) => _components.TryGet(entity, out component);
            /// <inheritdoc cref="Components.Get{T}(Entity)"/>
            public ref readonly T Get(Entity entity) => ref _components.Get<T>(entity);
            /// <inheritdoc cref="Components.Has{T}(Entity)"/>
            public bool Has(Entity entity) => _components.Has<T>(entity);
            /// <inheritdoc cref="Components.GetEnumerator()"/>
            public IEnumerator<(Entity entity, T component)> GetEnumerator() => _components.Get<T>().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        sealed class Injector : Injector<Components<T>>
        {
            public override Result<Components<T>> Inject(MemberInfo member, World world) => new Components<T>(world.Components());
        }

        sealed class Depender : IDepender
        {
            public IEnumerable<IDependency> Depend(MemberInfo member, World world)
            {
                yield return new Dependencies.Read(typeof(Entity));
                yield return new Dependencies.Write(typeof(T));
                yield return new Dependencies.Emit(typeof(Messages.OnAdd));
                yield return new Dependencies.Emit(typeof(Messages.OnAdd<T>));
                yield return new Dependencies.Emit(typeof(Messages.OnRemove));
                yield return new Dependencies.Emit(typeof(Messages.OnRemove<T>));
                foreach (var dependency in world.Dependers().Dependencies<T>()) yield return dependency;
            }
        }

        [Injector]
        static readonly Injector _injector = new Injector();
        [Depender]
        static readonly Depender _depender = new Depender();

        readonly Components _components;

        /// <summary>
        /// Initializes a new instance of the <see cref="Components{T}" /> struct.
        /// </summary>
        /// <param name="components"></param>
        public Components(Components components) { _components = components; }

        /// <inheritdoc cref="Components.GetOrAdd{T}(Entity, Func{T})"/>
        public ref T GetOrAdd(Entity entity, Func<T> create = null) => ref _components.GetOrAdd(entity, create);
        /// <inheritdoc cref="Components.GetOrDummy{T}(Entity, out bool)"/>
        [ThreadSafe]
        public ref T GetOrDummy(Entity entity, out bool success) => ref _components.GetOrDummy<T>(entity, out success);
        /// <inheritdoc cref="Components.TryGet{T}(Entity, out T)"/>
        [ThreadSafe]
        public bool TryGet(Entity entity, out T component) => _components.TryGet(entity, out component);
        /// <inheritdoc cref="Components.Get{T}(Entity)"/>
        [ThreadSafe]
        public ref T Get(Entity entity) => ref _components.Get<T>(entity);
        /// <inheritdoc cref="Components.Set{T}(Entity, in T)"/>
        public bool Set(Entity entity, in T component) => _components.Set(entity, component);
        /// <inheritdoc cref="Components.Has{T}(Entity)"/>
        [ThreadSafe]
        public bool Has(Entity entity) => _components.Has<T>(entity);
        /// <inheritdoc cref="Components.Remove{T}(Entity)"/>
        public bool Remove(Entity entity) => _components.Remove<T>(entity);
        /// <inheritdoc cref="Components.Clear{T}()"/>
        public bool Clear() => _components.Clear<T>();
        /// <inheritdoc cref="Components.GetEnumerator()"/>
        [ThreadSafe]
        public IEnumerator<(Entity entity, T component)> GetEnumerator() => _components.Get<T>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
