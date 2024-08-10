namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

public static class Dijkstra
{
  /// <summary>
  /// Executes Dijkstra's shortest path algorithm.
  /// </summary>
  /// <param name="graph">Graph represented by vertex IDs and their edges, each consisting of a neighbor vertex ID and edge weight.</param>
  /// <param name="startVertexId">The ID of the starting vertex.</param>
  /// <returns>A dictionary with vertex IDs as keys and PathInfo containing the shortest distance and path.</returns>
  public static Dictionary<int, PathInfo> Execute(Dictionary<int, List<(int, int)>> graph, int startVertexId)
  {
    var vertexIdsByDistancesFromStart = new Dictionary<int, int>();
    var priorityQueue = new SortedSet<(int distanceFromStart, int vertexId)>();
    var visited = new HashSet<int>();
    var predecessors = new Dictionary<int, int>();

    foreach (var vertexId in graph.Keys)
    {
      vertexIdsByDistancesFromStart[vertexId] = int.MaxValue;
    }
    vertexIdsByDistancesFromStart[startVertexId] = 0;
    priorityQueue.Add((0, startVertexId));

    while (priorityQueue.Count > 0)
    {
      var (currentDistanceFromStart, currentVertexId) = priorityQueue.Min;
      priorityQueue.Remove(priorityQueue.Min);

      if (visited.Contains(currentVertexId))
      {
        continue;
      }

      visited.Add(currentVertexId);

      foreach (var (neighborVertexId, neighborDistanceFromCurrentVertex) in graph[currentVertexId])
      {
        if (visited.Contains(neighborVertexId))
        {
          continue;
        }

        var newDistanceFromStart = currentDistanceFromStart + neighborDistanceFromCurrentVertex;

        if (newDistanceFromStart < vertexIdsByDistancesFromStart[neighborVertexId])
        {
          vertexIdsByDistancesFromStart[neighborVertexId] = newDistanceFromStart;
          predecessors[neighborVertexId] = currentVertexId;
          priorityQueue.Add((newDistanceFromStart, neighborVertexId));
        }
      }
    }

    var result = new Dictionary<int, PathInfo>();

    foreach (var vertexId in vertexIdsByDistancesFromStart.Keys)
    {
      var path = GetPath(predecessors, startVertexId, vertexId);
      result[vertexId] = new PathInfo
      {
        Distance = vertexIdsByDistancesFromStart[vertexId],
        Path = path
      };
    }

    return result;
  }

  /// <summary>
  /// Reconstructs the shortest path from the start vertex to the target vertex using the predecessors dictionary.
  /// </summary>
  /// <param name="predecessors">The dictionary containing the predecessor of each vertex.</param>
  /// <param name="startVertexId">The ID of the starting vertex.</param>
  /// <param name="targetVertexId">The ID of the target vertex.</param>
  /// <returns>A list representing the path from the start vertex to the target vertex.</returns>
  private static List<int> GetPath(Dictionary<int, int> predecessors, int startVertexId, int targetVertexId)
  {
    var path = new List<int>();
    var currentVertexId = targetVertexId;

    while (currentVertexId != startVertexId)
    {
      path.Add(currentVertexId);
      if (!predecessors.TryGetValue(currentVertexId, out int predecessor))
      {
        return [];
      }

      currentVertexId = predecessor;
    }

    path.Add(startVertexId);
    path.Reverse();
    return path;
  }
}

public class PathInfo
{
  public int Distance { get; set; }
  public List<int>? Path { get; set; }
}
