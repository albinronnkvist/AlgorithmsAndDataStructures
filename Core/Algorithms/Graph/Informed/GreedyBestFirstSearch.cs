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

        return [];
    }
}

public class GbfsNode(string state, GbfsNode? parent = null, int heuristic = 0)
{
    public string State { get; } = state;
    public GbfsNode? Parent { get; } = parent;
    public int Heuristic { get; } = heuristic;

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

public class GbfsEdge(GbfsNode node, int cost)
{
    public GbfsNode Node { get; } = node;
    public int Cost { get; } = cost;
}

public class GbfsGraph
{
    private readonly Dictionary<string, List<GbfsEdge>> _adjacencyList = [];

    public void AddEdge(GbfsNode fromNode, GbfsNode toNode, int cost)
    {
        if (!_adjacencyList.TryGetValue(fromNode.State, out List<GbfsEdge>? fromValue))
        {
            _adjacencyList[fromNode.State] = [];
        }
        else 
        {
            fromValue.Add(new GbfsEdge(toNode, cost));
        }

        if (!_adjacencyList.TryGetValue(toNode.State, out List<GbfsEdge>? toValue))
        {
            _adjacencyList[toNode.State] = [];
        }
        else
        {
            toValue.Add(new GbfsEdge(fromNode, cost));
        }
    }

    public List<GbfsEdge> GetNeighbors(GbfsNode node)
    {
        return _adjacencyList.TryGetValue(node.State, out List<GbfsEdge>? value) ? value : [];
    }
}
