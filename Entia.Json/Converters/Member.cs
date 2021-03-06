using System;
using Entia.Core;

namespace Entia.Json.Converters
{
    public sealed class Member<T>
    {
        public readonly string Name;
        public readonly string[] Aliases;
        public readonly Member.Convert<T> Convert;
        public readonly Member.Initialize<T> Initialize;

        public Member(string name, string[] aliases, Member.Convert<T> convert, Member.Initialize<T> initialize)
        {
            Name = name;
            Aliases = aliases;
            Convert = convert;
            Initialize = initialize;
        }
    }

    public static class Member
    {
        public delegate bool Validate<T>(in T instance);
        public delegate Node Convert<T>(in T instance, in ConvertToContext context);
        public delegate void Initialize<T>(ref T instance, in ConvertFromContext context);
        public delegate ref readonly TValue Get<T, TValue>(in T instance);
        public delegate TValue Getter<T, TValue>(in T instance);
        public delegate void Setter<T, TValue>(ref T instance, in TValue value);
        public delegate Node To<T>(in T instance, in ConvertToContext context);
        public delegate T From<T>(Node node, in ConvertFromContext context);

        static class Cache<T>
        {
            public static readonly To<T> To = (in T value, in ConvertToContext context) => context.Convert(value);
            public static readonly From<T> From = (Node node, in ConvertFromContext context) => context.Convert<T>(node);
            public static readonly Validate<T> Validate = (in T _) => true;
        }

        public static Member<T> Field<T, TValue>(string name, Get<T, TValue> get, To<TValue> to = null, From<TValue> from = null, Validate<TValue> validate = null, string[] aliases = null)
        {
            to ??= Cache<TValue>.To;
            from ??= Cache<TValue>.From;
            validate ??= Cache<TValue>.Validate;
            aliases ??= Array.Empty<string>();
            return new Member<T>(name, aliases,
                (in T instance, in ConvertToContext context) =>
                {
                    ref readonly var value = ref get(instance);
                    if (validate(value)) return to(value, context);
                    return default;
                },
                (ref T instance, in ConvertFromContext context) =>
                {
                    var value = from(context.Node, context);
                    if (validate(value)) UnsafeUtility.Set(get(instance), value);
                });
        }

        public static Member<T> Property<T, TValue>(string name, Getter<T, TValue> get, Setter<T, TValue> set, To<TValue> to = null, From<TValue> from = null, Validate<TValue> validate = null, string[] aliases = null)
        {
            to ??= Cache<TValue>.To;
            from ??= Cache<TValue>.From;
            validate ??= Cache<TValue>.Validate;
            aliases ??= Array.Empty<string>();
            return new Member<T>(name, aliases,
                (in T instance, in ConvertToContext context) =>
                {
                    var value = get(instance);
                    if (validate(value)) return to(value, context);
                    return default;
                },
                (ref T instance, in ConvertFromContext context) =>
                {
                    var value = from(context.Node, context);
                    if (validate(value)) set(ref instance, value);
                });
        }
    }
}