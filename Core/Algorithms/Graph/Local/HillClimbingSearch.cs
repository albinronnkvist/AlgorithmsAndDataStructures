namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Local;

public class HillClimbingSearch
{
    public static HillClimbingNode Execute(
        HillClimbingGraph graph,
        HillClimbingNode startNode,
        Func<HillClimbingNode, double> objectiveFunction,
        int maxIterations)
    {
        HillClimbingNode currentBestNode = startNode;
        double currentBestScore = objectiveFunction(currentBestNode);

        int iterations = 0;
        while (iterations < maxIterations)
        {
            var neighbors = graph.GetNeighbors(currentBestNode);

            HillClimbingNode? bestNeighbor = null;
            double bestNeighborScore = 0;

            // Determine the best neighbor using the objective function
            foreach (var edge in neighbors)
            {
                double currentNeighborScore = objectiveFunction(edge.Node);

                if (currentNeighborScore > bestNeighborScore)
                {
                    bestNeighbor = edge.Node;
                    bestNeighborScore = currentNeighborScore;
                }
            }

            // Check if the best neighbor is better than the current node
            if (bestNeighbor == null || bestNeighborScore <= currentBestScore)
            {
                break; // No better neighbor, stop the search
            }

            // Move to the better neighbor
            currentBestNode = bestNeighbor;
            currentBestScore = bestNeighborScore;
            iterations++;
        }

        return currentBestNode; // Return the best node found
    }
}

public class HillClimbingNode
{
    public string State { get; }
    public HillClimbingNode? Parent { get; }

    public HillClimbingNode(string state, HillClimbingNode? parent = null)
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

public class HillClimbingEdge
{
    public HillClimbingNode Node { get; }
    public double Score { get; }

    public HillClimbingEdge(HillClimbingNode node, double score)
    {
        Node = node;
        Score = score;
    }
}

public class HillClimbingGraph
{
    private readonly Dictionary<string, List<HillClimbingEdge>> _adjacencyList = new();

    public void AddEdge(HillClimbingNode fromNode, HillClimbingNode toNode, double score)
    {
        if (!_adjacencyList.TryGetValue(fromNode.State, out var fromNeighbors))
        {
            fromNeighbors = new List<HillClimbingEdge>();
            _adjacencyList[fromNode.State] = fromNeighbors;
        }
        fromNeighbors.Add(new HillClimbingEdge(toNode, score));

        if (!_adjacencyList.TryGetValue(toNode.State, out var toNeighbors))
        {
            toNeighbors = new List<HillClimbingEdge>();
            _adjacencyList[toNode.State] = toNeighbors;
        }
        toNeighbors.Add(new HillClimbingEdge(fromNode, score));
    }

    public List<HillClimbingEdge> GetNeighbors(HillClimbingNode node)
    {
        return _adjacencyList.TryGetValue(node.State, out var neighbors) ? neighbors : new List<HillClimbingEdge>();
    }
}