using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Uninformed;

public class UniformCostSearchTests
{
    [Fact]
    public void FindPath_ShouldReturnOptimalPath_WhenPathExists()
    {
        var graph = new UcsGraph();
        var arad = new UcsNode("Arad");
        var sibiu = new UcsNode("Sibiu");
        var timisoara = new UcsNode("Timisoara");
        var rimnicuVilcea = new UcsNode("Rimnicu Vilcea");
        var bucharest = new UcsNode("Bucharest");

        graph.AddEdge(arad, sibiu, 140);
        graph.AddEdge(arad, timisoara, 118);
        graph.AddEdge(sibiu, rimnicuVilcea, 80);
        graph.AddEdge(rimnicuVilcea, bucharest, 97);
        graph.AddEdge(sibiu, bucharest, 199);

        var (path, cost) = UniformCostSearch.FindPath(graph, arad, "Bucharest");

        path.Should().BeEquivalentTo(new List<string> { "Arad", "Sibiu", "Rimnicu Vilcea", "Bucharest" }, 
                                        options => options.WithStrictOrdering());
        cost.Should().Be(317);
    }

    [Fact]
    public void FindPath_ShouldReturnEmptyPath_WhenNoPathExists()
    {
        var graph = new UcsGraph();
        var arad = new UcsNode("Arad");
        var sibiu = new UcsNode("Sibiu");
        var bucharest = new UcsNode("Bucharest");

        graph.AddEdge(arad, sibiu, 140);

        var (path, cost) = UniformCostSearch.FindPath(graph, arad, "Bucharest");

        path.Should().BeEmpty();
        cost.Should().Be(0);
    }

    [Fact]
    public void FindPath_ShouldReturnStartNode_WhenStartEqualsGoal()
    {
        var graph = new UcsGraph();
        var arad = new UcsNode("Arad");

        var (path, cost) = UniformCostSearch.FindPath(graph, arad, "Arad");

        path.Should().BeEquivalentTo(new List<string> { "Arad" });
        cost.Should().Be(0);
    }
}
