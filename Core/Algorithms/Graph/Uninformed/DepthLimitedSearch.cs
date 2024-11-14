namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

public class DepthLimitedSearch
{
    public static List<string> Execute(DlsGraph graph, DlsNode start, string goalState, int depthLimit)
    {
        var stack = new Stack<(DlsNode Node, int Depth)>();
        var visited = new HashSet<string>();

        stack.Push((start, 0));
        visited.Add(start.State);

        while (stack.Count > 0)
        {
            var (currentNode, currentDepth) = stack.Peek();

            // Goal check
            if (currentNode.State.Equals(goalState))
            {
                return stack
                    .Reverse()
                    .Select(node => node.Node.State)
                    .ToList();
            }

            // Depth limit check
            if (currentDepth < depthLimit)
            {
                bool hasUnvisitedNeighbors = false;
                
                foreach (var neighbor in graph.GetNeighbors(currentNode))
                {
                    if (!visited.Contains(neighbor.State))
                    {
                        stack.Push((neighbor, currentDepth + 1));
                        visited.Add(neighbor.State);
                        hasUnvisitedNeighbors = true;
                        break;
                    }
                }

                // If no unvisited neighbors, backtrack by popping the stack
                if (!hasUnvisitedNeighbors)
                {
                    stack.Pop();
                }
            }
            else 
            {
                stack.Pop();
            }
        }

        return new List<string>();
    }
}

public class DlsNode
{
    public string State { get; }

    public DlsNode(string state)
    {
        State = state;
    }
}

public class DlsGraph
{
    private readonly Dictionary<DlsNode, List<DlsNode>> _adjacencyList = new();

    public void AddEdge(DlsNode from, DlsNode to)
    {
        if (!_adjacencyList.ContainsKey(from))
        {
            _adjacencyList[from] = new List<DlsNode>();
        }
        if (!_adjacencyList.ContainsKey(to))
        {
            _adjacencyList[to] = new List<DlsNode>();
        }

        _adjacencyList[from].Add(to);
        _adjacencyList[to].Add(from);
    }

    public List<DlsNode> GetNeighbors(DlsNode node)
    {
        return _adjacencyList.ContainsKey(node) ? _adjacencyList[node] : new List<DlsNode>();
    }
}