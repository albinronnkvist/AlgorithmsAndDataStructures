using Albin.AlgorithmsAndDataStructures.Core.Graph;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Graph;

public class DijkstraTests
{
    [Fact]
    public void Dijkstra_FindsShortestPath_FromStartVertex_ToAllVertices()
    {
        var graph = new Dictionary<int, List<(int, int)>>()
        {
            { 0, new List<(int, int)> { (1, 4), (2, 1) } },
            { 1, new List<(int, int)> { (3, 1) } },
            { 2, new List<(int, int)> { (1, 2), (3, 5) } },
            { 3, new List<(int, int)>() }
        };

        var expectedDistances = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 3 },
            { 2, 1 },
            { 3, 4 }
        };

        var result = Dijkstra.Execute(graph, 0);

        Assert.Equal(expectedDistances.Count, result.Count);
        foreach (var key in expectedDistances.Keys)
        {
            Assert.Equal(expectedDistances[key], result[key]);
        }
    }
}