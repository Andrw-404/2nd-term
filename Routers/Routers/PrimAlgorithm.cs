// <copyright file="PrimAlgorithm.cs" company="Kalinin Andrew">
// Copyright (c) Kalinin Andrew. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Implementation of the Prim algorithm for constructing a maximal spanning tree.
/// </summary>
public class PrimAlgorithm
{
    /// <summary>
    /// Finds the maximum spanning tree (MST) for a given graph.
    /// </summary>
    /// <param name="graph">The source graph read from the file.</param>
    /// <returns>List of mst edges.</returns>
    /// <exception cref="InvalidOperationException">
    /// It is thrown if the graph is disconnected.
    /// </exception>
    public static List<Edge> FindMaximumSpanningTree(Graph graph)
    {
        var mst = new List<Edge>();
        var visited = new HashSet<int>();
        var edgesQueue = new PriorityQueue<Edge, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        var allVertexes = graph.GetAllVertexes.ToList();
        if (allVertexes.Count == 0)
        {
            return mst;
        }

        var start = allVertexes.First();
        visited.Add(start);

        foreach (var edge in graph.GetAdjacentEdges(start))
        {
            edgesQueue.Enqueue(edge, edge.Weight);
        }

        while (edgesQueue.Count > 0 && visited.Count < allVertexes.Count)
        {
            var edge = edgesQueue.Dequeue();
            var next = visited.Contains(edge.Start) ? edge.End : edge.Start;

            if (visited.Contains(next))
            {
                continue;
            }

            mst.Add(edge);
            visited.Add(next);

            foreach (var e in graph.GetAdjacentEdges(next))
            {
                if (!visited.Contains(e.Start))
                {
                    edgesQueue.Enqueue(e, e.Weight);
                }
            }
        }

        if (visited.Count != allVertexes.Count)
        {
            throw new InvalidOperationException("Граф несвязный");
        }

        return mst;
    }
}
