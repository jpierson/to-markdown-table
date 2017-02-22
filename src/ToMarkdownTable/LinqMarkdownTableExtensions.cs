using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Linq
{
    public static class LinqMarkdownTableExtensions
    {
        public static string ToMarkdownTable<T>(this IEnumerable<T> source)
        {
            var properties = typeof(T).GetRuntimeProperties();

            var maxColumnValues = source
                .Select(x => properties.Select(p => p.GetValue(x)?.ToString()?.Length ?? 0))
                .Union(new[] { properties.Select(p => p.Name.Length) }) // Include header in column sizes
                .Aggregate(
                    new int[properties.Count()].AsEnumerable(),
                    (accumulate, x) => accumulate.Zip(x, Math.Max))
                .ToArray();

            var columnNames = properties.Select(p => p.Name);

            var headerLine = "| " + string.Join(" | ", columnNames.Select((n, i) => n.PadRight(maxColumnValues[i]))) + " |";
            var headerDataDividerLine = "| " + string.Join(" | ", properties.Select((n, i) => new string('-', maxColumnValues[i]))) + " |";

            var lines = new[]
                {
                    headerLine,
                    headerDataDividerLine,
                }.Union(
                    source
                    .Select(s =>
                        "| " + string.Join(" | ", properties.Select((n, i) => (n.GetValue(s)?.ToString() ?? "").PadRight(maxColumnValues[i]))) + " |"));

            return lines
                .Aggregate((p, c) => p + Environment.NewLine + c);
        }
    }
}
