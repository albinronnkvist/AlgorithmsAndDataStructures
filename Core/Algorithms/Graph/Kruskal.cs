namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

public record Edge(int Weight, int FirstVertexId, int SecondVertexId);

public static class Kruskal
{
    public static int Execute(IReadOnlyCollection<Edge> edges)
    {
        throw new NotImplementedException();
    }
}

/*
Kruskal's Algorithm is a greedy algorithm used to find the Minimum Spanning Tree (MST) of an undirected edge-weighted graph. 
The MST is a subset of the edges of the graph that connects all vertices together, without any cycles, and with the minimum possible total edge weight.

There are two methods to implement Kruskal's Algorithm, either assemble or disassemble.

Steps of assemble:
1. Start with an empty graph
2. Add the edge with the lowest weight to the graph. If there are multiple edges with the same weight, choose any one of them.
3. Add the next shortest edge to the graph.
4. Add the next shortest edge to the graph which wouldn't create a cycle.
5. Repeat until there are no more edges to add.

Steps of dissasemble:
1. Remove the edge with the highest weight, but only if it's a part of a cycle.
2. Repeat until there are no more cycles.
*/