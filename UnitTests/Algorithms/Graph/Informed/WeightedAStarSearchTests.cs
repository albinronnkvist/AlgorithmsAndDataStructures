using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Informed;

public class WeightedAStarSearchTests
{
    /* 
    * This test verifies that the Weighted A* Search algorithm selects a path based on the weighted total cost 
    * (f(n) = g(n) + w * h(n)), which skews the search towards heuristic values for faster results.
    * 
    * Expected Result: With w = 2.0, Weighted A* should favor Path 1 due to its lower overall weighted heuristic value, 
    * as the algorithm prioritizes the heuristic more heavily with the increased weight, 
    * even though Path 2 has the lower actual travel cost (optimal in standard A*).
    */
    [Fact]
    public void Execute_ShouldReturnFasterButPotentiallySuboptimalPath_WhenUsingWeightedAStar()
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

        // Heuristic values (straight-line distance to Bucharest)
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

        // Execute Weighted A* with a weight factor of 2
        var result = WeightedAStarSearch.Execute(graph, arad, "Bucharest", heuristic, 2.0);

        result.Should().BeEquivalentTo(new List<string> { "Arad", "Sibiu", "Fagaras", "Bucharest" }, options => options.WithStrictOrdering());
    }
}
