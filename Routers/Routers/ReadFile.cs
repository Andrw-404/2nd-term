// <copyright file="ReadFile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers
{
    /// <summary>
    /// Implementing reading from a file.
    /// </summary>
    public class ReadFile
    {
        /// <summary>
        /// Implementing reading from a file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The constructed graph.</returns>
        public static Graph ReadFromFile(string path)
        {
            var graph = new Graph();

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                bool tryParseFirstPart = int.TryParse(parts[0], out int start);
                if (!tryParseFirstPart)
                {
                    continue;
                }

                string[] edgesInLine = parts[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var edge in edgesInLine)
                {
                    var cleanEdge = edge.Trim();
                    var indexOfBracket = cleanEdge.IndexOf('(');
                    var endBracketIndex = cleanEdge.IndexOf(')');

                    if (!int.TryParse(cleanEdge.Substring(0, indexOfBracket).Trim(), out int end))
                    {
                        continue;
                    }

                    if (!int.TryParse(cleanEdge.Substring(indexOfBracket + 1, endBracketIndex - indexOfBracket - 1).Trim(), out int weight))
                    {
                        continue;
                    }

                    graph.AddEdges(new Edge(start, end, weight));
                }
            }

            return graph;
        }
    }
}
