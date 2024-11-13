using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph;

public class BreadthFirstSearchTests
{
    [Fact]
    public void BFS_ShouldFindShortestPath_WhenPathExists()
    {
        /*
                 Arad
                /    \
            Sibiu  Timisoara
                |
            Bucharest
        */
        var graph = new UndirectedGraph();
        var arad = new Node("Arad");
        var sibiu = new Node("Sibiu", arad);
        var timisoara = new Node("Timisoara", arad);
        var bucharest = new Node("Bucharest", sibiu);

        graph.AddNode(arad);
        graph.AddNode(sibiu);
        graph.AddNode(timisoara);
        graph.AddNode(bucharest);

        var path = BreadthFirstSearch.Execute(graph, arad, bucharest.State);

        path.Should().BeEquivalentTo(new List<string> { "Arad", "Sibiu", "Bucharest" }, 
                options => options.WithStrictOrdering());
        bucharest.Depth.Should().Be(2);
    }

    [Fact]
    public void BFS_ShouldReturnEmptyPath_WhenNoPathExists()
    {
        var graph = new UndirectedGraph();
        var arad = new Node("Arad");
        var bucharest = new Node("Bucharest");

        graph.AddNode(arad);
        graph.AddNode(bucharest);

        var path = BreadthFirstSearch.Execute(graph, arad, bucharest.State);

        path.Should().BeEmpty();
    }

    [Fact]
    public void BFS_ShouldReturnStartNode_WhenStartEqualsGoal()
    {
        var graph = new UndirectedGraph();
        var arad = new Node("Arad");

        graph.AddNode(arad);

        var path = BreadthFirstSearch.Execute(graph, arad, arad.State);

        path.Should().BeEquivalentTo(new List<string> { "Arad" });
    }
}