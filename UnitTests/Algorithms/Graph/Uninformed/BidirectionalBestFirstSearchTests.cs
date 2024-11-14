using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Uninformed;

public class BidirectionalBestFirstSearchTests
{
    [Fact]
    public void Execute_ShouldReturnDirectPath_WhenPathExists()
    {
        var graph = new BbfsGraph();
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("B", "C", 2);

        var result = BidirectionalBestFirstSearch.Execute(graph, "A", "C");

        result.Should().BeEquivalentTo(new List<string> { "A", "B", "C" }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void Execute_ShouldReturnShortestPath_WhenAlternativePathsExist()
    {
        var graph = new BbfsGraph();
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "D", 3);
        graph.AddEdge("B", "C", 1);
        graph.AddEdge("B", "E", 2);
        graph.AddEdge("D", "C", 1);

        var result = BidirectionalBestFirstSearch.Execute(graph, "A", "C");

        result.Should().BeEquivalentTo(new List<string> { "A", "B", "C" }, options => options.WithStrictOrdering());
    }
}
