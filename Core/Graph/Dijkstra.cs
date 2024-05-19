namespace Albin.AlgorithmsAndDataStructures.Core.Graph;

public static class Dijkstra
{
  /// <summary>
  /// Executes Dijkstra's shortest path algorithm.
  /// </summary>
  /// <param name="graph">Graph represented by vertex IDs and their edges, each consisting of a neighbor vertex ID and edge weight.</param>
  /// <param name="startVertexId">The ID of the starting vertex.</param>
  /// <returns>A dictionary with the shortest path distances from the start vertex to all other vertices.</returns>
  public static Dictionary<int, int> Execute(Dictionary<int, List<(int, int)>> graph, int startVertexId)
  {
    // Stores the shortest known distance from the start vertex to each vertex.
    var vertexIdsByDistancesFromStart = new Dictionary<int, int>();
    
    // Priority queue to select the next vertex to process based on the shortest known distance.
    var priorityQueue = new SortedSet<(int distanceFromStart, int vertexId)>();

    // Tracks processed vertices to avoid reprocessing.
    // When a vertex is marked as visited, it means that the shortest path from the start vertex to this vertex has been found. 
    // Dijkstra's algorithm is designed on the principle that once the shortest path to a vertex is found, it does not change. Revisiting vertices contradicts this principle and can lead to incorrect path calculations.
    var visited = new HashSet<int>();

    // The distances from start to each other vertex is unknown at this point,
    // So we initialize distances to all vertices as a very high number (usually infinity in maths)
    foreach (var vertexId in graph.Keys)
    {
      vertexIdsByDistancesFromStart[vertexId] = int.MaxValue;
    }

    // Distance from start to start is always zero.
    vertexIdsByDistancesFromStart[startVertexId] = 0;

    // Add the start vertex to the priority queue with a distance of zero.
    priorityQueue.Add((0, startVertexId));

    // Main loop to calculate shortest distances from the start vertex to all other vertices.
    while (priorityQueue.Count > 0)
    {
      // Get the vertex with the smallest known distance from the start vertex.
      // - In the first loop this will be the start vertex itself
      // - In the second loop this will be one neighbor of the start vertex with the shortest distance from start
      // - In the third loop it might be another neighbor of the start vertex or a neighbor of the neighbor in the step above
      var (currentDistanceFromStart, currentVertexId) = priorityQueue.Min;
      priorityQueue.Remove(priorityQueue.Min);

      // Skip processing if the vertex has already been visited.
      if (visited.Contains(currentVertexId))
      {
        continue;
      }

      // Mark the current vertex as visited.
      visited.Add(currentVertexId);

      // Calculate distances to each neighbor of the current vertex.
      foreach (var (neighborVertexId, neighborDistanceFromCurrentVertex) in graph[currentVertexId])
      {
        // Skip processing if the neighbor has already been visited.
        if (visited.Contains(neighborVertexId))
        {
          continue;
        }

        // Calculate the new distance from the start to the neighbor vertex.
        var newDistanceFromStart = currentDistanceFromStart + neighborDistanceFromCurrentVertex;

        // If the new calculated distance is shorter than the current known distance (int.MaxValue by default), 
        // update the shortest distance for the vertex
        if (newDistanceFromStart < vertexIdsByDistancesFromStart[neighborVertexId])
        {
          vertexIdsByDistancesFromStart[neighborVertexId] = newDistanceFromStart;

          // Add the neighbor to the priority queue for further processing.
          priorityQueue.Add((newDistanceFromStart, neighborVertexId));
        }
      }
    }

    return vertexIdsByDistancesFromStart;
  }
}
