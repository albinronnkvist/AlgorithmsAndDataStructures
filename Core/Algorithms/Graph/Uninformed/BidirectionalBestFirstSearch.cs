namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

public class BidirectionalBestFirstSearch
{
    public static List<string> Execute(BbfsGraph graph, string startState, string goalState)
    {
        var forwardQueue = new PriorityQueue<BbfsNode, int>();
        var backwardQueue = new PriorityQueue<BbfsNode, int>();

        var forwardVisited = new Dictionary<string, BbfsNode>();
        var backwardVisited = new Dictionary<string, BbfsNode>();

        var startNode = new BbfsNode(startState, null, 0);
        var goalNode = new BbfsNode(goalState, null, 0);

        forwardQueue.Enqueue(startNode, 0);
        forwardVisited[startState] = startNode;

        backwardQueue.Enqueue(goalNode, 0);
        backwardVisited[goalState] = goalNode;

        while (forwardQueue.Count > 0 && backwardQueue.Count > 0)
        {
            // Expand from the forward direction
            if (ExpandLayer(graph, forwardQueue, forwardVisited, backwardVisited, out var meetingNode))
            {
                return ConstructPath(meetingNode, forwardVisited, backwardVisited);
            }

            // Expand from the backward direction
            if (ExpandLayer(graph, backwardQueue, backwardVisited, forwardVisited, out meetingNode))
            {
                return ConstructPath(meetingNode, forwardVisited, backwardVisited);
            }
        }

        return new List<string>();
    }

    private static bool ExpandLayer(BbfsGraph graph, PriorityQueue<BbfsNode, int> queue,
        Dictionary<string, BbfsNode> visited, Dictionary<string, BbfsNode> oppositeVisited, out BbfsNode? meetingNode)
    {
        if (queue.Count == 0)
        {
            meetingNode = null;
            return false;
        }

        var currentNode = queue.Dequeue();

        foreach (var neighbor in graph.GetNeighbors(currentNode))
        {
            if (!visited.ContainsKey(neighbor.State) || neighbor.PathCost < visited[neighbor.State].PathCost)
            {
                var neighborNode = new BbfsNode(neighbor.State, currentNode,
                    currentNode.PathCost + graph.GetEdgeCost(currentNode.State, neighbor.State));
                visited[neighbor.State] = neighborNode;
                queue.Enqueue(neighborNode, neighborNode.PathCost);

                // Check if this node has been visited by the opposite direction
                if (oppositeVisited.ContainsKey(neighbor.State))
                {
                    meetingNode = neighborNode;
                    return true;
                }
            }
        }

        meetingNode = null;
        return false;
    }

    private static List<string> ConstructPath(BbfsNode? meetingNode, Dictionary<string,
        BbfsNode> forwardVisited, Dictionary<string, BbfsNode> backwardVisited)
    {
        if (meetingNode is null)
        {
            throw new InvalidOperationException("No meeting node found.");
        }

        var path = new List<string>();

        // Forward path from start to meeting node
        var forwardPath = new List<string>();
        var current = forwardVisited[meetingNode.State];
        while (current is not null)
        {
            forwardPath.Add(current.State);
            current = current.Parent;
        }
        forwardPath.Reverse();

        // Backward path from meeting node to goal
        var backwardPath = new List<string>();
        current = backwardVisited[meetingNode.State]?.Parent; // Exclude meeting node to avoid duplication
        while (current != null)
        {
            backwardPath.Add(current.State);
            current = current.Parent;
        }

        // Combine forward and backward paths
        return forwardPath.Concat(backwardPath).ToList();
    }
}

public class BbfsNode
{
    public string State { get; }
    public BbfsNode? Parent { get; }
    public int PathCost { get; }

    public BbfsNode(string state, BbfsNode? parent, int pathCost)
    {
        State = state;
        Parent = parent;
        PathCost = pathCost;
    }
}

public class BbfsGraph
{
    private readonly Dictionary<string, List<(string State, int Cost)>> _adjacencyList = new();

    public void AddEdge(string from, string to, int cost)
    {
        if (!_adjacencyList.ContainsKey(from))
        {
            _adjacencyList[from] = new List<(string State, int Cost)>();
        }
        if (!_adjacencyList.ContainsKey(to))
        {
            _adjacencyList[to] = new List<(string State, int Cost)>();
        }

        _adjacencyList[from].Add((to, cost));
        _adjacencyList[to].Add((from, cost));
    }

    public List<BbfsNode> GetNeighbors(BbfsNode node)
    {
        return _adjacencyList.ContainsKey(node.State)
            ? _adjacencyList[node.State].Select(neighbor => new BbfsNode(neighbor.State, node, node.PathCost + neighbor.Cost)).ToList()
            : new List<BbfsNode>();
    }

    public int GetEdgeCost(string from, string to)
    {
        return _adjacencyList[from].FirstOrDefault(neighbor => neighbor.State == to).Cost;
    }
}
