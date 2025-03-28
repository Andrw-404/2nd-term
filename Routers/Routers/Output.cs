// <copyright file="Output.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers
{
    class Output
    {
        public static string TransformationMst(List<Edge> mst)
        {
            var uniqueEdges = new HashSet<(int, int)>();
            var output = new Dictionary<int, List<string>>();

            foreach (var edge in mst)
            {
                var (a, b) = (Math.Min(edge.Start, edge.End), Math.Max(edge.Start, edge.End));
                if (uniqueEdges.Add((a, b)))
                {
                    if (!output.ContainsKey(a))
                    {
                        output[a] = new List<string>();
                    }

                    output[a].Add($"{b} ({edge.Weight})");
                }
            }

            var result = new List<string>();
            foreach (var kv in output.OrderBy(x => x.Key))
            {
                result.Add($"{kv.Key}: {string.Join(", ", kv.Value.OrderBy(x => x))}");
            }

            return string.Join("\n", result);
        }
    }
}
