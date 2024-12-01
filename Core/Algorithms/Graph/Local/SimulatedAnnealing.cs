namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Local;

public class SimulatedAnnealing
{
    public static SimulatedAnnealingNode Execute(
        SimulatedAnnealingGraph graph,
        SimulatedAnnealingNode startNode,
        Func<SimulatedAnnealingNode, double> objectiveFunction,
        Func<int, double> schedule,
        int maxIterations)
    {
        SimulatedAnnealingNode currentBestNode = startNode;
        double currentBestScore = objectiveFunction(currentBestNode);

        Random random = new Random();

        for (int t = 1; t <= maxIterations; t++)
        {
            double temperature = schedule(t);
            if (temperature is 0) return currentBestNode;

            // Get neighbors of the current node
            var neighbors = graph.GetNeighbors(currentBestNode);
            if (neighbors.Count is 0) return currentBestNode;

            // Choose a random neighbor
            var randomNeighbor = neighbors[random.Next(neighbors.Count)].Node;
            double neighborScore = objectiveFunction(randomNeighbor);

            double deltaE = currentBestScore - neighborScore;

            // Decide whether to move to the neighbor
            if (deltaE > 0 || random.NextDouble() < Math.Exp(-deltaE / temperature))
            {
                currentBestNode = randomNeighbor;
                currentBestScore = neighborScore;
            }
        }

        return currentBestNode;
    }
}

public class SimulatedAnnealingNode
{
    public string State { get; }
    public SimulatedAnnealingNode? Parent { get; }

    public SimulatedAnnealingNode(string state, SimulatedAnnealingNode? parent = null)
    {
        State = state;
        Parent = parent;
    }

    public List<string> GetPath()
    {
        var path = new List<string>();
        var current = this;
        while (current != null)
        {
            path.Add(current.State);
            current = current.Parent;
        }

        path.Reverse();
        return path;
    }
}

public class SimulatedAnnealingEdge
{
    public SimulatedAnnealingNode Node { get; }
    public double Score { get; }

    public SimulatedAnnealingEdge(SimulatedAnnealingNode node, double score)
    {
        Node = node;
        Score = score;
    }
}

public class SimulatedAnnealingGraph
{
    private readonly Dictionary<string, List<SimulatedAnnealingEdge>> _adjacencyList = new();

    public void AddEdge(SimulatedAnnealingNode fromNode, SimulatedAnnealingNode toNode, double score)
    {
        if (!_adjacencyList.TryGetValue(fromNode.State, out var fromNeighbors))
        {
            fromNeighbors = new List<SimulatedAnnealingEdge>();
            _adjacencyList[fromNode.State] = fromNeighbors;
        }
        fromNeighbors.Add(new SimulatedAnnealingEdge(toNode, score));

        if (!_adjacencyList.TryGetValue(toNode.State, out var toNeighbors))
        {
            toNeighbors = new List<SimulatedAnnealingEdge>();
            _adjacencyList[toNode.State] = toNeighbors;
        }
        toNeighbors.Add(new SimulatedAnnealingEdge(fromNode, score));
    }

    public List<SimulatedAnnealingEdge> GetNeighbors(SimulatedAnnealingNode node)
    {
        return _adjacencyList.TryGetValue(node.State, out var neighbors) ? neighbors : new List<SimulatedAnnealingEdge>();
    }
}