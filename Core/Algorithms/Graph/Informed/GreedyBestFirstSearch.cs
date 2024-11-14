namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

public class GreedyBestFirstSearch
{
    public static List<string> Execute(GbfsGraph graph, GbfsNode start, string goalState)
    {
        var frontier = new PriorityQueue<GbfsNode, int>();
        var reached = new HashSet<string>();
        
        frontier.Enqueue(start, start.Heuristic);
        reached.Add(start.State);

        while (frontier.Count > 0)
        {
            var currentNode = frontier.Dequeue();

            // Goal check on expansion
            if (currentNode.State.Equals(goalState))
            {
                return currentNode.GetPath();
            }

            foreach (var edge in graph.GetNeighbors(currentNode))
            {
                var childNode = new GbfsNode(edge.Node.State, currentNode, edge.Node.Heuristic);

                if (!reached.Contains(childNode.State))
                {
                    reached.Add(childNode.State);
                    frontier.Enqueue(childNode, childNode.Heuristic);
                }
            }
        }

        return new List<string>();
    }
}

public class GbfsNode
{
    public string State { get; }
    public GbfsNode? Parent { get; }
    public int Heuristic { get; }

    public GbfsNode(string state, GbfsNode? parent = null, int heuristic = 0)
    {
        State = state;
        Parent = parent;
        Heuristic = heuristic;
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

public class GbfsEdge
{
    public GbfsNode Node { get; }
    public int Cost { get; }

    public GbfsEdge(GbfsNode node, int cost)
    {
        Node = node;
        Cost = cost;
    }
}

public class GbfsGraph
{
    private Dictionary<string, List<GbfsEdge>> _adjacencyList = new();

    public void AddEdge(GbfsNode fromNode, GbfsNode toNode, int cost)
    {
        if (!_adjacencyList.ContainsKey(fromNode.State))
        {
            _adjacencyList[fromNode.State] = new List<GbfsEdge>();
        }
        if (!_adjacencyList.ContainsKey(toNode.State))
        {
            _adjacencyList[toNode.State] = new List<GbfsEdge>();
        }

        _adjacencyList[fromNode.State].Add(new GbfsEdge(toNode, cost));
        _adjacencyList[toNode.State].Add(new GbfsEdge(fromNode, cost));
    }

    public List<GbfsEdge> GetNeighbors(GbfsNode node)
    {
        return _adjacencyList.ContainsKey(node.State) ? _adjacencyList[node.State] : new List<GbfsEdge>();
    }
}
