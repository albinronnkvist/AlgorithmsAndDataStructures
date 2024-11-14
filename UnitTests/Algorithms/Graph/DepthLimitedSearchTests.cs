using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph;

public class DepthLimitedSearchTests
{
    [Fact]
    public void Execute_ShouldReturnPath_WhenGoalWithinDepthLimit()
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

        var result = DepthLimitedSearch.Execute(graph, a, "E", 3);

        result.Should().BeEquivalentTo(new List<string> { "A", "B", "D", "E" }, options => options.WithStrictOrdering());
    }

    /*
          A
         / \
        B   C
       / \   \
      D   E   F
               \
                G
    */
    [Fact]
    public void Execute_ShouldHandleBacktrackingCorrectly()
    {
        var graph = new DlsGraph();
        var a = new DlsNode("A");
        var b = new DlsNode("B");
        var c = new DlsNode("C");
        var d = new DlsNode("D");
        var e = new DlsNode("E");
        var f = new DlsNode("F");
        var g = new DlsNode("G");

        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(b, e);
        graph.AddEdge(c, f);
        graph.AddEdge(f, g);

        var result = DepthLimitedSearch.Execute(graph, a, "G", 3);

        result.Should().BeEquivalentTo(new List<string> { "A", "C", "F", "G" }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void Execute_ShouldReturnSingleNodePath_WhenStartIsGoal()
    {
        var graph = new DlsGraph();
        var a = new DlsNode("A");

        var result = DepthLimitedSearch.Execute(graph, a, "A", 2);

        result.Should().BeEquivalentTo(new List<string> { "A" });
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

        var result = DepthLimitedSearch.Execute(graph, a, "E", 2);

        result.Should().BeEmpty();
    }
}
