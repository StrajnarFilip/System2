using System;
using System.Collections.Generic;
using System.Linq;

namespace System2.DataStructures
{
    public static class TreeExtensions
    {
        public static T DepthFirstSearch<T>(
            this T rootVertex,
            Func<T, IEnumerable<T>> extractChildVertices,
            Func<T, bool> vertexMatch
        )
            where T : class
        {
            if (rootVertex is null)
                return null;
            if (vertexMatch(rootVertex))
                return rootVertex;

            var childVertices = extractChildVertices(rootVertex);

            return childVertices
                ?.Select(vertex => vertex.DepthFirstSearch(extractChildVertices, vertexMatch))
                .FirstOrDefault(result => !(result is null));
        }

        public static T BreadthFirstSearch<T>(
            this T rootVertex,
            Func<T, IEnumerable<T>> extractChildVertices,
            Func<T, bool> vertexMatch
        )
            where T : class
        {
            if (rootVertex is null)
                return null;

            var currentVertices = new[] { rootVertex };

            while (currentVertices.Any())
            {
                foreach (var vertex in currentVertices)
                {
                    if (vertex is null)
                        continue;
                    if (vertexMatch(vertex))
                        return vertex;
                }

                currentVertices = currentVertices
                    .SelectMany(vertex => extractChildVertices(vertex) ?? Array.Empty<T>())
                    .ToArray();
            }

            return null;
        }
    }
}
