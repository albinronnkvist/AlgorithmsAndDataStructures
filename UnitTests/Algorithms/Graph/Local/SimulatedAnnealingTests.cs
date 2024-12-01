using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Local;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Graph.Local;

public class SimulatedAnnealingTests
{
    [Fact]
    public void Execute_ShouldReturnStartNode_WhenNoNeighborsExist()
    {
        var startNode = new SimulatedAnnealingNode("A");
        var graph = new SimulatedAnnealingGraph();
        Func<SimulatedAnnealingNode, double> objectiveFunction = node => 5.0;
        Func<int, double> schedule = t => 100.0 / t;

        var result = SimulatedAnnealing.Execute(graph, startNode, objectiveFunction, schedule, maxIterations: 100);

        result.Should().Be(startNode);
    }

    [Fact]
    public void Execute_ShouldFindGlobalOptimum_WhenTemperatureIsSufficient()
    {
        var a = new SimulatedAnnealingNode("A");
        var b = new SimulatedAnnealingNode("B");
        var c = new SimulatedAnnealingNode("C");

        var graph = new SimulatedAnnealingGraph();
        graph.AddEdge(a, b, 0); // A -> B
        graph.AddEdge(b, c, 0); // B -> C

        Func<SimulatedAnnealingNode, double> objectiveFunction = node => node.State switch
        {
            "A" => 10.0,
            "B" => 5.0,
            "C" => 1.0,
            _ => double.MaxValue
        };

        Func<int, double> schedule = t => 100.0 / t;

        var result = SimulatedAnnealing.Execute(graph, a, objectiveFunction, schedule, maxIterations: 1000);

        result.Should().Be(c);
    }
}
