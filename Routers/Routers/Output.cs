// <copyright file="Output.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers
{
    /// <summary>
    /// MST formatting for convenient output.
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Converts the list of MST edges to a string format.
        /// </summary>
        /// <param name="mst">List of mst edges.</param>
        /// <returns>returns a string like: [router] : [paired router] (bandwidth), ... .</returns>
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
