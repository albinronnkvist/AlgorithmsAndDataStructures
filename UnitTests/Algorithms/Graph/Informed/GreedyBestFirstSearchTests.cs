using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Informed;

public class GreedyBestFirstSearchTests
{
    /* 
     * This test verifies that the Greedy Best-First Search (GBFS) algorithm selects the path 
     * with the lowest heuristic values, even when another path exists with a lower actual travel cost.
     * 
     * Setup:
     * - There are two main paths from "Arad" to "Bucharest":
     * 
     *   Path 1: Arad -> Sibiu -> Fagaras -> Bucharest
     *   - Heuristic sum: 366 (Arad) + 253 (Sibiu) + 176 (Fagaras) + 0 (Bucharest) = 795
     *   - Travel cost: 140 (Arad to Sibiu) + 99 (Sibiu to Fagaras) + 211 (Fagaras to Bucharest) = 450
     * 
     *   Path 2: Arad -> Sibiu -> Rimnicu Vilcea -> Pitesti -> Bucharest
     *   - Heuristic sum: 366 (Arad) + 253 (Sibiu) + 193 (Rimnicu Vilcea) + 100 (Pitesti) + 0 (Bucharest) = 912
     *   - Travel cost: 140 (Arad to Sibiu) + 80 (Sibiu to Rimnicu Vilcea) + 97 (Rimnicu Vilcea to Pitesti) + 101 (Pitesti to Bucharest) = 418
     * 
     * Expected Result: Since GBFS only considers heuristic values, it should choose Path 1 
     * because it has a lower heuristic sum (795) than Path 2 (912), even though Path 2 has a lower actual travel cost.
     */
    [Fact]
    public void Execute_ShouldReturnShortestHeuristicPath_WhenMultiplePathsExist()
    {
        var graph = new GbfsGraph();

        // Nodes with heuristic values towards Bucharest
        var arad = new GbfsNode("Arad", null, 366);
        var zerind = new GbfsNode("Zerind", null, 374);
        var oradea = new GbfsNode("Oradea", null, 380);
        var sibiu = new GbfsNode("Sibiu", null, 253);
        var rimnicuVilcea = new GbfsNode("Rimnicu Vilcea", null, 193);
        var fagaras = new GbfsNode("Fagaras", null, 176);
        var pitesti = new GbfsNode("Pitesti", null, 100);
        var bucharest = new GbfsNode("Bucharest", null, 0);

        // Edges with travel costs
        graph.AddEdge(arad, zerind, 75);
        graph.AddEdge(arad, sibiu, 140);
        graph.AddEdge(zerind, oradea, 71);
        graph.AddEdge(sibiu, fagaras, 99);
        graph.AddEdge(sibiu, rimnicuVilcea, 80);
        graph.AddEdge(rimnicuVilcea, pitesti, 97);
        graph.AddEdge(fagaras, bucharest, 211);
        graph.AddEdge(pitesti, bucharest, 101);

        var result = GreedyBestFirstSearch.Execute(graph, arad, "Bucharest");

        result.Should().BeEquivalentTo(new List<string> { "Arad", "Sibiu", "Fagaras", "Bucharest" }, options => options.WithStrictOrdering());
    }
}