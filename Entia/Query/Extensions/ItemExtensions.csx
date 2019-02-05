using System;
using System.Collections.Generic;
using System.Linq;

enum Names { First = 1, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Tenth }

IEnumerable<string> Generate(int depth)
{
    IEnumerable<string> GenericParameters(int count)
    {
        for (var i = 1; i <= count; i++)
            yield return $"T{i}";
    }

    IEnumerable<string> TupleParameters(int count, int index, Func<string, string> wrap)
    {
        for (var i = 1; i <= count; i++)
        {
            if (i == index) yield return wrap("T" + i);
            else yield return "T" + i;
        }
    }

    string AnyType(int count, int index, Func<string, string> wrap) => $"Any<{string.Join(", ", TupleParameters(count, index, wrap))}>";
    string AllType(int count, int index, Func<string, string> wrap) => $"All<{string.Join(", ", TupleParameters(count, index, wrap))}>";

    for (var i = 2; i <= depth; i++)
    {
        const string item = "item";
        var parameters = GenericParameters(i).ToArray();
        var generics = string.Join(", ", parameters);
        var constraints = string.Join(" ", parameters.Select(generic => $"where {generic} : struct, IQueryable"));
        var allOuts = string.Join(", ", parameters.Select((parameter, index) => $"out {parameter} value{index + 1}"));
        var anyOuts = string.Join(", ", parameters.Select((parameter, index) => $"out Maybe<{parameter}> value{index + 1}"));
        var assignments = string.Join(Environment.NewLine, parameters.Select((_, index) => $"value{index + 1} = {item}.Value{index + 1};"));

        yield return
$@"public static void Deconstruct<{generics}>(in this {AllType(i, -1, null)} {item}, {allOuts}) {constraints}
{{
    {assignments}
}}";

        yield return
$@"public static void Deconstruct<{generics}>(in this {AnyType(i, -1, null)} {item}, {anyOuts}) {constraints}
{{
    {assignments}
}}";
    }
}

var file = "ItemExtensions";
var code =
$@"/* DO NOT MODIFY: The content of this file has been generated by the script '{file}.csx'. */

using Entia.Core.Documentation;

namespace Entia.Queryables
{{
    [ThreadSafe]
    public static class ItemExtensions
    {{
        public static void Deconstruct<T>(in this Read<T> item, out T value) where T : struct, IComponent => value = item.Value;
        public static void Deconstruct<T>(in this Write<T> item, out T value) where T : struct, IComponent => value = item.Value;

        {string.Join(Environment.NewLine, Generate(7))}
    }}
}}";

File.WriteAllText($"./{file}.cs", code);