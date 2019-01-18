using System;
using System.Runtime.CompilerServices;
using Entia.Core;
using Entia.Dependables;
using Entia.Modules.Component;
using Entia.Modules.Query;
using Entia.Queriers;
using Entia.Queryables;

namespace Entia.Queryables
{
    public readonly struct Read<T> : IQueryable, IDepend<Dependables.Read<T>> where T : struct, IComponent
    {
        sealed class Querier : Querier<Read<T>>
        {
            public override bool TryQuery(Segment segment, World world, out Query<Read<T>> query)
            {
                if (segment.Has<T>())
                {
                    var metadata = ComponentUtility.Cache<T>.Data;
                    query = new Query<Read<T>>(index => new Read<T>(segment.GetStore<T>(), index), metadata);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        public ref readonly T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _array[_index];
        }

        readonly T[] _array;
        readonly int _index;

        public Read(T[] array, int index)
        {
            _array = array;
            _index = index;
        }
    }
}