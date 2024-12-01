using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Local;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Local;

public class HillClimbingSearchTests
{
    [Fact]
    public void Execute_ShouldReturnStartNode_WhenNoBetterNeighborExists()
    {
        var a = new HillClimbingNode("A");
        var graph = new HillClimbingGraph();
        Func<HillClimbingNode, double> objectiveFunction = node => 1.0;

        var result = HillClimbingSearch.Execute(graph, a, objectiveFunction, maxIterations: 10);

        result.Should().Be(a);
    }

    [Fact]
    public void Execute_ShouldClimbToHighestScoreNode()
    {
        var a = new HillClimbingNode("A");
        var b = new HillClimbingNode("B");
        var c = new HillClimbingNode("C");

        var graph = new HillClimbingGraph();
        graph.AddEdge(a, b, 0); // A -> B
        graph.AddEdge(b, c, 0); // B -> C

        Func<HillClimbingNode, double> objectiveFunction = node => node.State switch
        {
            "A" => 1.0,
            "B" => 2.0,
            "C" => 3.0,
            _ => 0.0
        };

        var result = HillClimbingSearch.Execute(graph, a, objectiveFunction, maxIterations: 10);

        result.Should().Be(c);
    }

    [Fact]
    public void Execute_ShouldStopAtLocalMaximum()
    {
        var a = new HillClimbingNode("A");
        var b = new HillClimbingNode("B");
        var c = new HillClimbingNode("C");
        var d = new HillClimbingNode("D");

        var graph = new HillClimbingGraph();
        graph.AddEdge(a, b, 0); // A -> B
        graph.AddEdge(b, c, 0); // B -> C
        graph.AddEdge(c, d, 0); // C -> D

        Func<HillClimbingNode, double> objectiveFunction = node => node.State switch
        {
            "A" => 1.0,
            "B" => 3.0, // Local maximum
            "C" => 2.0,
            "D" => 5.0, // Global maximum will not be reached
            _ => 0.0
        };

        var result = HillClimbingSearch.Execute(graph, a, objectiveFunction, maxIterations: 10);

        result.Should().Be(b);
    }
}
