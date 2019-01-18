﻿using Entia.Core;
using Entia.Modules.Build;
using Entia.Modules.Control;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entia.Nodes
{
    public static class NodeExtensions
    {
        public static IEnumerable<Node> Family(this Node node) => node.Descendants().Append(node);
        public static IEnumerable<Node> Descendants(this Node node) => node.Children.SelectMany(Family);
        public static Node Descend(this Node node, Func<Node, Node> replace) =>
            replace(Node.Of(node.Name, node.Value, node.Children.Select(child => child.Descend(replace)).ToArray()));

        public static Node Profile(this Node node, bool recursive = true) => recursive ?
            node.Descend(child => child.Value is IWrapper ? child : child.Profile(false)) :
            Node.Of<Profile>(node.Name, node);

        public static Node Do(this Node node, Action<IRunner> @do) =>
            Node.Of(node.Name, new Map { Mapper = runner => { @do(runner); return Result.Success(runner); } }, node);

        public static Node Flatten(this Node node, bool recursive = true)
        {
            if (node.Value is IAtomic) return node;
            var children = recursive ? node.Children.Select(child => child.Flatten(recursive)).ToArray() : node.Children;
            return Node.Of(node.Name, node.Value, children
                .SelectMany(child => child.Value is IAtomic || child.Children.Length == 0 ? new[] { child } : child.Children)
                .ToArray());
        }

        public static Node State(this Node node, Func<Controller.States> get) => Node.Of(node.Name, new State { Get = get }, node);
        public static Node Map(this Node node, Func<IRunner, Option<IRunner>> map) => Node.Of(node.Name, new Map { Mapper = map }, node);
        public static Node Repeat(this Node node, int count) => Node.Of(node.Name, node.Value, node.Children.Repeat(count).ToArray());
        public static Node Distinct(this Node node) => Node.Of(node.Name, node.Value, node.Children.Distinct().ToArray());
        public static Node Separate(this Node node, Node separator, bool recursive = true) => node.Separate(() => separator, recursive);
        public static Node Separate(this Node node, Func<Node> provider, bool recursive = true)
        {
            if (node.Value is IAtomic) return node;
            var children = recursive ? node.Children.Select(child => child.Separate(provider, recursive)).ToArray() : node.Children;
            return Node.Of(node.Name, node.Value, children.Separate(provider).ToArray());
        }

        public static Node Resolve(this Node node)
        {
            var children = node.Children.Select(child => child.Value is IAtomic ? Node.Resolve(child) : child.Resolve()).ToArray();
            return Node.Of(node.Name, node.Value, children);
        }
    }
}
