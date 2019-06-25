/* DO NOT MODIFY: The content of this file has been generated by the script 'All.csx'. */

using Entia.Core.Documentation;
using Entia.Modules;
using Entia.Modules.Query;
using Entia.Queriers;

namespace Entia.Queryables
{
    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2))
                {
                    query = new Query<All<T1, T2>>(index => new All<T1, T2>(query1.Get(index), query2.Get(index)), query1.Types, query2.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2) { Value1 = value1; Value2 = value2; }
    }

    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2, T3> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2, T3>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2, T3>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2) && queriers.TryQuery<T3>(context, out var query3))
                {
                    query = new Query<All<T1, T2, T3>>(index => new All<T1, T2, T3>(query1.Get(index), query2.Get(index), query3.Get(index)), query1.Types, query2.Types, query3.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;
        /// <summary>
        /// The value3.
        /// </summary>
        public readonly T3 Value3;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2, T3}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2, in T3 value3) { Value1 = value1; Value2 = value2; Value3 = value3; }
    }

    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2, T3, T4> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2, T3, T4>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2, T3, T4>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2) && queriers.TryQuery<T3>(context, out var query3) && queriers.TryQuery<T4>(context, out var query4))
                {
                    query = new Query<All<T1, T2, T3, T4>>(index => new All<T1, T2, T3, T4>(query1.Get(index), query2.Get(index), query3.Get(index), query4.Get(index)), query1.Types, query2.Types, query3.Types, query4.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;
        /// <summary>
        /// The value3.
        /// </summary>
        public readonly T3 Value3;
        /// <summary>
        /// The value4.
        /// </summary>
        public readonly T4 Value4;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2, T3, T4}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2, in T3 value3, in T4 value4) { Value1 = value1; Value2 = value2; Value3 = value3; Value4 = value4; }
    }

    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2, T3, T4, T5> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2, T3, T4, T5>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2, T3, T4, T5>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2) && queriers.TryQuery<T3>(context, out var query3) && queriers.TryQuery<T4>(context, out var query4) && queriers.TryQuery<T5>(context, out var query5))
                {
                    query = new Query<All<T1, T2, T3, T4, T5>>(index => new All<T1, T2, T3, T4, T5>(query1.Get(index), query2.Get(index), query3.Get(index), query4.Get(index), query5.Get(index)), query1.Types, query2.Types, query3.Types, query4.Types, query5.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;
        /// <summary>
        /// The value3.
        /// </summary>
        public readonly T3 Value3;
        /// <summary>
        /// The value4.
        /// </summary>
        public readonly T4 Value4;
        /// <summary>
        /// The value5.
        /// </summary>
        public readonly T5 Value5;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2, T3, T4, T5}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5) { Value1 = value1; Value2 = value2; Value3 = value3; Value4 = value4; Value5 = value5; }
    }

    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2, T3, T4, T5, T6> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2, T3, T4, T5, T6>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2, T3, T4, T5, T6>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2) && queriers.TryQuery<T3>(context, out var query3) && queriers.TryQuery<T4>(context, out var query4) && queriers.TryQuery<T5>(context, out var query5) && queriers.TryQuery<T6>(context, out var query6))
                {
                    query = new Query<All<T1, T2, T3, T4, T5, T6>>(index => new All<T1, T2, T3, T4, T5, T6>(query1.Get(index), query2.Get(index), query3.Get(index), query4.Get(index), query5.Get(index), query6.Get(index)), query1.Types, query2.Types, query3.Types, query4.Types, query5.Types, query6.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;
        /// <summary>
        /// The value3.
        /// </summary>
        public readonly T3 Value3;
        /// <summary>
        /// The value4.
        /// </summary>
        public readonly T4 Value4;
        /// <summary>
        /// The value5.
        /// </summary>
        public readonly T5 Value5;
        /// <summary>
        /// The value6.
        /// </summary>
        public readonly T6 Value6;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2, T3, T4, T5, T6}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5, in T6 value6) { Value1 = value1; Value2 = value2; Value3 = value3; Value4 = value4; Value5 = value5; Value6 = value6; }
    }

    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct All<T1, T2, T3, T4, T5, T6, T7> : IQueryable where T1 : struct, IQueryable where T2 : struct, IQueryable where T3 : struct, IQueryable where T4 : struct, IQueryable where T5 : struct, IQueryable where T6 : struct, IQueryable where T7 : struct, IQueryable
    {
        sealed class Querier : Querier<All<T1, T2, T3, T4, T5, T6, T7>>
        {
            public override bool TryQuery(in Context context, out Query<All<T1, T2, T3, T4, T5, T6, T7>> query)
            {
                var queriers = context.World.Queriers();
                if (queriers.TryQuery<T1>(context, out var query1) && queriers.TryQuery<T2>(context, out var query2) && queriers.TryQuery<T3>(context, out var query3) && queriers.TryQuery<T4>(context, out var query4) && queriers.TryQuery<T5>(context, out var query5) && queriers.TryQuery<T6>(context, out var query6) && queriers.TryQuery<T7>(context, out var query7))
                {
                    query = new Query<All<T1, T2, T3, T4, T5, T6, T7>>(index => new All<T1, T2, T3, T4, T5, T6, T7>(query1.Get(index), query2.Get(index), query3.Get(index), query4.Get(index), query5.Get(index), query6.Get(index), query7.Get(index)), query1.Types, query2.Types, query3.Types, query4.Types, query5.Types, query6.Types, query7.Types);
                    return true;
                }

                query = default;
                return false;
            }
        }

        [Querier]
        static readonly Querier _querier = new Querier();

        /// <summary>
        /// The value1.
        /// </summary>
        public readonly T1 Value1;
        /// <summary>
        /// The value2.
        /// </summary>
        public readonly T2 Value2;
        /// <summary>
        /// The value3.
        /// </summary>
        public readonly T3 Value3;
        /// <summary>
        /// The value4.
        /// </summary>
        public readonly T4 Value4;
        /// <summary>
        /// The value5.
        /// </summary>
        public readonly T5 Value5;
        /// <summary>
        /// The value6.
        /// </summary>
        public readonly T6 Value6;
        /// <summary>
        /// The value7.
        /// </summary>
        public readonly T7 Value7;

        /// <summary>
        /// Initializes a new instance of the <see cref="All{T1, T2, T3, T4, T5, T6, T7}"/> struct.
        /// </summary>
        public All(in T1 value1, in T2 value2, in T3 value3, in T4 value4, in T5 value5, in T6 value6, in T7 value7) { Value1 = value1; Value2 = value2; Value3 = value3; Value4 = value4; Value5 = value5; Value6 = value6; Value7 = value7; }
    }
}