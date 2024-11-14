namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

public class DepthFirstSearchWithBacktracking
{
    public static List<string> Execute(DfsGraph graph, DfsNode start, string goalState)
    {
        var stack = new Stack<DfsNode>();
        var visited = new HashSet<string>();

        stack.Push(start);
        visited.Add(start.State);

        while (stack.Count > 0)
        {
            var currentNode = stack.Peek();

            // Goal check
            if (currentNode.State.Equals(goalState))
            {
                return stack
                    .Reverse()
                    .Select(node => node.State)
                    .ToList();
            }

            bool hasUnvisitedNeighbors = false;
            foreach (var neighbor in graph.GetNeighbors(currentNode))
            {
                if (!visited.Contains(neighbor.State))
                {
                    stack.Push(neighbor);
                    visited.Add(neighbor.State);
                    hasUnvisitedNeighbors = true;
                    break;
                }
            }

            // If no unvisited neighbors, pop to backtrack
            if (!hasUnvisitedNeighbors)
            {
                stack.Pop();
            }
        }

        return new List<string>();
    }
}

public class DfsNode
{
    public string State { get; }

    public DfsNode(string state)
    {
        State = state;
    }
}

public class DfsGraph
{
    private readonly Dictionary<DfsNode, List<DfsNode>> _adjacencyList = new();

    public void AddEdge(DfsNode from, DfsNode to)
    {
        if (!_adjacencyList.ContainsKey(from))
        {
            _adjacencyList[from] = new List<DfsNode>();
        }
        if (!_adjacencyList.ContainsKey(to))
        {
            _adjacencyList[to] = new List<DfsNode>();
        }

        _adjacencyList[from].Add(to);
        _adjacencyList[to].Add(from);
    }

    public List<DfsNode> GetNeighbors(DfsNode node)
    {
        return _adjacencyList.ContainsKey(node) ? _adjacencyList[node] : new List<DfsNode>();
    }
}