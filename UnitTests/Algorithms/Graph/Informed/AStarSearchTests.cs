using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Informed;

public class AStarSearchTests
{
    /* 
    * This test verifies that the A* Search algorithm selects the path with the lowest actual travel cost (g(n)), 
    * while evaluating nodes based on the evaluated total cost (f(n) = g(n) + h(n)).
    * In this case, the heuristic is addmissible, so the algorithm is cost-optimal.
    * 
    * Setup:
    * - There are two main paths from "Arad" to "Bucharest":
    * 
    *   Path 1: Arad -> Sibiu -> Fagaras -> Bucharest
    *   - h(n): 366 (Arad) + 253 (Sibiu) + 176 (Fagaras) + 0 (Bucharest) = 795
    *   - g(n): 140 (Arad to Sibiu) + 99 (Sibiu to Fagaras) + 211 (Fagaras to Bucharest) = 450
    *   - f(n): 
    *     - Arad: g(Arad) = 0, h(Arad) = 366, f(Arad) = 0 + 366 = 366
    *     - Sibiu: g(Sibiu) = 140, h(Sibiu) = 253, f(Sibiu) = 140 + 253 = 393
    *     - Fagaras: g(Fagaras) = 239, h(Fagaras) = 176, f(Fagaras) = 239 + 176 = 415
    *     - Bucharest: g(Bucharest) = 450, h(Bucharest) = 0, f(Bucharest) = 450 + 0 = 450
    * 
    *   Path 2: Arad -> Sibiu -> Rimnicu Vilcea -> Pitesti -> Bucharest
    *   - h(n): 366 (Arad) + 253 (Sibiu) + 193 (Rimnicu Vilcea) + 100 (Pitesti) + 0 (Bucharest) = 912
    *   - g(n): 140 (Arad to Sibiu) + 80 (Sibiu to Rimnicu Vilcea) + 97 (Rimnicu Vilcea to Pitesti) + 101 (Pitesti to Bucharest) = 418
    *   - f(n): 
    *     - Arad: g(Arad) = 0, h(Arad) = 366, f(Arad) = 0 + 366 = 366
    *     - Sibiu: g(Sibiu) = 140, h(Sibiu) = 253, f(Sibiu) = 140 + 253 = 393
    *     - Rimnicu Vilcea: g(Rimnicu Vilcea) = 220, h(Rimnicu Vilcea) = 193, f(Rimnicu Vilcea) = 220 + 193 = 413
    *     - Pitesti: g(Pitesti) = 317, h(Pitesti) = 100, f(Pitesti) = 317 + 100 = 417
    *     - Bucharest: g(Bucharest) = 418, h(Bucharest) = 0, f(Bucharest) = 418 + 0 = 418
    * 
    * Expected Result: Since A* evaluates paths based on the evaluated total cost (f(n) = g(n) + h(n)), 
    * it should prioritize Path 2 during exploration because it has a lower evaluated total cost (418 vs. 450).
    * 
    * Path 2 also has the lowest actual travel cost (g(n) = 418), demonstrating its ability to balance actual cost and heuristic estimation.
    */
    [Fact]
    public void Execute_ShouldReturnShortestPath_WhenMultiplePathsExist()
    {
        var graph = new AStarGraph();

        // Add nodes
        var arad = new AStarNode("Arad");
        var zerind = new AStarNode("Zerind");
        var oradea = new AStarNode("Oradea");
        var sibiu = new AStarNode("Sibiu");
        var rimnicuVilcea = new AStarNode("Rimnicu Vilcea");
        var fagaras = new AStarNode("Fagaras");
        var pitesti = new AStarNode("Pitesti");
        var bucharest = new AStarNode("Bucharest");

        // Add edges with costs
        graph.AddEdge(arad, zerind, 75);
        graph.AddEdge(arad, sibiu, 140);
        graph.AddEdge(zerind, oradea, 71);
        graph.AddEdge(sibiu, fagaras, 99);
        graph.AddEdge(sibiu, rimnicuVilcea, 80);
        graph.AddEdge(rimnicuVilcea, pitesti, 97);
        graph.AddEdge(fagaras, bucharest, 211);
        graph.AddEdge(pitesti, bucharest, 101);

        // Define heuristic values (straight-line distance to Bucharest)
        Func<string, int> heuristic = state => state switch
        {
            "Arad" => 366,
            "Zerind" => 374,
            "Oradea" => 380,
            "Sibiu" => 253,
            "Rimnicu Vilcea" => 193,
            "Fagaras" => 176,
            "Pitesti" => 100,
            "Bucharest" => 0,
            _ => int.MaxValue
        };

        var result = AStarSearch.Execute(graph, arad, "Bucharest", heuristic);

        result.Should().BeEquivalentTo(new List<string> { "Arad", "Sibiu", "Rimnicu Vilcea", "Pitesti", "Bucharest" }, options => options.WithStrictOrdering());
    }
}
