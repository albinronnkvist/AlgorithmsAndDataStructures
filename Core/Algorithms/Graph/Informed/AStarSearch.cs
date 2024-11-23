namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

public class AStarSearch
{
    public static List<string> Execute(AStarGraph graph, AStarNode start, string goalState, Func<string, int> heuristic)
    {
        var frontier = new PriorityQueue<AStarNode, int>();
        var reached = new Dictionary<string, int>();

        frontier.Enqueue(start, 0 + heuristic(start.State));
        reached[start.State] = 0;

        while (frontier.Count > 0)
        {
            var currentNode = frontier.Dequeue();

            // Goal check
            if (currentNode.State.Equals(goalState))
            {
                return currentNode.GetPath();
            }

            foreach (var edge in graph.GetNeighbors(currentNode))
            {
                var neighbor = edge.Node;
                int newCost = reached[currentNode.State] + edge.Cost;

                if (!reached.ContainsKey(neighbor.State) || newCost < reached[neighbor.State])
                {
                    reached[neighbor.State] = newCost;
                    frontier.Enqueue(new AStarNode(neighbor.State, currentNode), newCost + heuristic(neighbor.State));
                }
            }
        }

        return [];
    }
}

public class AStarNode
{
    public string State { get; }
    public AStarNode? Parent { get; }

    public AStarNode(string state, AStarNode? parent = null)
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

public class AStarEdge
{
    public AStarNode Node { get; }
    public int Cost { get; }

    public AStarEdge(AStarNode node, int cost)
    {
        Node = node;
        Cost = cost;
    }
}

public class AStarGraph
{
    private readonly Dictionary<string, List<AStarEdge>> _adjacencyList = new();

    public void AddEdge(AStarNode fromNode, AStarNode toNode, int cost)
    {
        if (!_adjacencyList.TryGetValue(fromNode.State, out var fromNeighbors))
        {
            fromNeighbors = [];
            _adjacencyList[fromNode.State] = fromNeighbors;
        }
        fromNeighbors.Add(new AStarEdge(toNode, cost));

        if (!_adjacencyList.TryGetValue(toNode.State, out var toNeighbors))
        {
            toNeighbors = [];
            _adjacencyList[toNode.State] = toNeighbors;
        }
        toNeighbors.Add(new AStarEdge(fromNode, cost));
    }

    public List<AStarEdge> GetNeighbors(AStarNode node)
    {
        return _adjacencyList.TryGetValue(node.State, out var neighbors) ? neighbors : [];
    }
}
