using System;
using System.Text;
using Entia.Core;

namespace Entia.Experiment.Json
{
    public static partial class Serialization
    {
        public enum Format { Compact, Indented }

        public static string Serialize<T>(in T instance, ConvertOptions options = ConvertOptions.All, Format format = Format.Compact, Container container = null, params object[] references) =>
            Generate(Convert(instance, options, container, references), format);
        public static string Serialize(object instance, Type type, ConvertOptions options = ConvertOptions.All, Format format = Format.Compact, Container container = null, params object[] references) =>
            Generate(Convert(instance, type, options, container, references), format);

        public static string Generate(Node node, Format format = Format.Compact)
        {
            var builder = new StringBuilder(64);
            switch (format)
            {
                case Format.Compact: GenerateCompact(node, builder); break;
                case Format.Indented: GenerateIndented(node, builder, 0); break;
            }
            return builder.ToString();
        }

        static void GenerateCompact(Node node, StringBuilder builder)
        {
            switch (node.Kind)
            {
                case Node.Kinds.Null:
                case Node.Kinds.Boolean:
                case Node.Kinds.Number: builder.Append(node.Value); break;
                case Node.Kinds.String:
                    builder.Append('"');
                    builder.Append(node.Value);
                    builder.Append('"');
                    break;
                case Node.Kinds.Array:
                    builder.Append('[');
                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        if (i > 0) builder.Append(',');
                        GenerateCompact(node.Children[i], builder);
                    }
                    builder.Append(']');
                    break;
                case Node.Kinds.Object:
                    builder.Append('{');
                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        if (i > 0) builder.Append(',');
                        GenerateCompact(node.Children[i], builder);
                    }
                    builder.Append('}');
                    break;
                case Node.Kinds.Member:
                    if (node.TryMember(out var key, out var value))
                    {
                        GenerateCompact(key, builder);
                        builder.Append(':');
                        GenerateCompact(value, builder);
                    }
                    break;
            }
        }

        static void GenerateIndented(Node node, StringBuilder builder, int indent)
        {
            switch (node.Kind)
            {
                case Node.Kinds.Null:
                case Node.Kinds.Boolean:
                case Node.Kinds.Number: builder.Append(node.Value); break;
                case Node.Kinds.String:
                    builder.Append('"');
                    builder.Append(node.Value);
                    builder.Append('"');
                    break;
                case Node.Kinds.Array:
                    builder.Append('[');
                    builder.AppendLine();
                    indent++;
                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        if (i > 0)
                        {
                            builder.Append(',');
                            builder.AppendLine();
                        }
                        Indent(indent, builder);
                        GenerateIndented(node.Children[i], builder, indent);
                    }
                    indent--;
                    builder.AppendLine();
                    Indent(indent, builder);
                    builder.Append(']');
                    break;
                case Node.Kinds.Object:
                    builder.Append('{');
                    builder.AppendLine();
                    indent++;
                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        if (i > 0)
                        {
                            builder.Append(',');
                            builder.AppendLine();
                        }
                        Indent(indent, builder);
                        GenerateIndented(node.Children[i], builder, indent);
                    }
                    indent--;
                    builder.AppendLine();
                    Indent(indent, builder);
                    builder.Append('}');
                    break;
                case Node.Kinds.Member:
                    if (node.TryMember(out var key, out var value))
                    {
                        GenerateIndented(key, builder, indent);
                        builder.Append(": ");
                        GenerateIndented(value, builder, indent);
                    }
                    break;
            }
        }

        static void Indent(int indent, StringBuilder builder) => builder.Append(new string(' ', indent * 2));
    }
}