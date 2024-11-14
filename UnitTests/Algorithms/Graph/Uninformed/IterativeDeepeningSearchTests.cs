using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Uninformed;

public class IterativeDeepeningSearchTests
{
    /*
         A
        / \
        B  C
        |
        D
        |
        E
    */
    [Fact]
    public void Execute_ShouldReturnPath_WhenGoalWithinDepthLimit()
    {
        var graph = new DlsGraph();
        var a = new DlsNode("A");
        var b = new DlsNode("B");
        var c = new DlsNode("C");
        var d = new DlsNode("D");
        var e = new DlsNode("E");

        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(d, e);

        var result = IterativeDeepeningSearch.Execute(graph, a, "E", maxDepth: 3);

        result.Should().BeEquivalentTo(new List<string> { "A", "B", "D", "E" }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void Execute_ShouldReturnEmptyList_WhenGoalBeyondDepthLimit()
    {
        var graph = new DlsGraph();
        var a = new DlsNode("A");
        var b = new DlsNode("B");
        var c = new DlsNode("C");
        var d = new DlsNode("D");
        var e = new DlsNode("E");

        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(d, e);

        var result = IterativeDeepeningSearch.Execute(graph, a, "E", maxDepth: 2);

        result.Should().BeEmpty();
    }
}
