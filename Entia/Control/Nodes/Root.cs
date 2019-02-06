using System;
using System.Collections.Generic;
using System.Linq;
using Entia.Builders;
using Entia.Core;
using Entia.Modules;
using Entia.Modules.Build;
using Entia.Modules.Control;
using Entia.Modules.Schedule;
using Entia.Phases;

namespace Entia.Nodes
{
    public readonly struct Root : IWrapper
    {
        sealed class Runner : IRunner
        {
            public object Instance => Child;
            public readonly IRunner Child;
            public Runner(IRunner child) { Child = child; }

            public IEnumerable<Type> Phases() => Child.Phases();
            public IEnumerable<Phase> Phases(Controller controller) => Child.Phases(controller);
            public Option<Runner<T>> Specialize<T>(Controller controller) where T : struct, IPhase
            {
                var run = default(InAction<T>);
                var set = new HashSet<object>();
                foreach (var phase in Phases(controller))
                {
                    if (phase.Target == Phase.Targets.Root && phase.Type == typeof(T) && set.Add(phase.Distinct) && phase.Delegate is InAction<T> @delegate)
                        run += @delegate;
                }
                if (Child.Specialize<T>(controller).TryValue(out var child)) return new Runner<T>(child.Run + run);
                else if (run == null) return Option.None();
                else return new Runner<T>(run);
            }
        }

        sealed class Builder : Builder<Runner>
        {
            public override Result<Runner> Build(Node node, Node root, World world) => Result.Cast<Root>(node.Value)
                .Bind(_ => world.Builders().Build(Node.Sequence(node.Name, node.Children), root))
                .Map(child => new Runner(child));
        }

        [Builder]
        static readonly Builder _builder = new Builder();
    }
}