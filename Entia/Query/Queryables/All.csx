IEnumerable<string> Generate(int depth)
{
    IEnumerable<string> GenericParameters(int count)
    {
        for (var i = 1; i <= count; i++)
            yield return $"T{i}";
    }

    var context = "context";
    var world = $"{context}.World";
    var queriers = "queriers";
    for (var i = 2; i <= depth; i++)
    {
        var generics = GenericParameters(i).ToArray();
        var parameters = string.Join(", ", generics);
        var type = $"All<{parameters}>";
        var constraints = string.Join(" ", generics.Select(generic => $"where {generic} : struct, IQueryable"));
        var fields = string.Join(Environment.NewLine, generics.Select((generic, index) =>
$@"        /// <summary>
        /// The value{index + 1}.
        /// </summary>
        public readonly {generic} Value{index + 1};"));
        var inValues = string.Join(", ", generics.Select((generic, index) => $"in {generic} value{index + 1}"));
        var initializers = string.Join(" ", generics.Select((_, index) => $"Value{index + 1} = value{index + 1};"));

        var tryQueries = string.Join(
            $" && ",
            generics.Select((generic, index) => $"{queriers}.TryQuery<{generic}>({context}, out var query{index + 1})"));
        var queryGets = string.Join(
            $", ",
            generics.Select((_, index) => $"query{index + 1}.Get(index)"));
        var queryTypes = string.Join(
            $", ",
            generics.Select((_, index) => $"query{index + 1}.Types"));

        yield return
$@"    /// <summary>
    /// Query that must satisfy all its sub queries.
    /// </summary>
    [ThreadSafe]
    public readonly struct {type} : IQueryable {constraints}
    {{
        sealed class Querier : Querier<{type}>
        {{
            public override bool TryQuery(in Context {context}, out Query<{type}> query)
            {{
                var {queriers} = {world}.Queriers();
                if ({tryQueries})
                {{
                    query = new Query<{type}>(index => new {type}({queryGets}), {queryTypes});
                    return true;
                }}

                query = default;
                return false;
            }}
        }}

        [Querier]
        static readonly Querier _querier = new Querier();

{fields}

        /// <summary>
        /// Initializes a new instance of the <see cref=""All{{{parameters}}}""/> struct.
        /// </summary>
        public All({inValues}) {{ {initializers} }}
    }}";
    }
}

var file = "All";
var code =
$@"/* DO NOT MODIFY: The content of this file has been generated by the script '{file}.csx'. */

using Entia.Core.Documentation;
using Entia.Modules;
using Entia.Modules.Query;
using Entia.Queriers;

namespace Entia.Queryables
{{
{string.Join(Environment.NewLine + Environment.NewLine, Generate(7))}
}}";

File.WriteAllText($"./{file}.cs", code);