using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph;

public class DepthFirstSearchWithBacktrackingTests
{
    /*
           A
          / \
         B   C
        /     \
       D       G
    */
    [Fact]
    public void Execute_ShouldReturnPath_WhenPathExists()
    {
        var graph = new DfsGraph();
        var a = new DfsNode("A");
        var b = new DfsNode("B");
        var c = new DfsNode("C");
        var d = new DfsNode("D");
        var g = new DfsNode("G");

        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(c, g);

        var result = DepthFirstSearchWithBacktracking.Execute(graph, a, "G");

        result.Should()
            .BeEquivalentTo(new List<string> { "A", "C", "G" }, options => options.WithStrictOrdering());
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
        var graph = new DfsGraph();
        var a = new DfsNode("A");
        var b = new DfsNode("B");
        var c = new DfsNode("C");
        var d = new DfsNode("D");
        var e = new DfsNode("E");
        var f = new DfsNode("F");
        var g = new DfsNode("G");

        graph.AddEdge(a, b);
        graph.AddEdge(a, c);
        graph.AddEdge(b, d);
        graph.AddEdge(b, e);
        graph.AddEdge(c, f);
        graph.AddEdge(f, g);

        var result = DepthFirstSearchWithBacktracking.Execute(graph, a, "G");

        result.Should().BeEquivalentTo(new List<string> { "A", "C", "F", "G" }, options => options.WithStrictOrdering());
    }
}
