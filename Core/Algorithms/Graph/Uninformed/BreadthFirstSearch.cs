namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Uninformed;

public class BreadthFirstSearch
{
    public static List<string> Execute(UndirectedGraph graph, BfsNode startState, string goalState)
    {
        var frontier = new Queue<BfsNode>();
        frontier.Enqueue(startState);
        var reached = new HashSet<BfsNode> { startState };

        while (frontier.Count > 0)
        {
            var currentNode = frontier.Dequeue();

            // Early goal test
            if (currentNode.State.Equals(goalState))
            {
                return currentNode.GetPath();
            }

            // Expand node and add succeccors to reached and the end of the frontier
            foreach (var neighbor in graph.GetNeighbors(currentNode))
            {
                if (!reached.Contains(neighbor))
                {
                    reached.Add(neighbor);
                    frontier.Enqueue(neighbor);
                }
            }
        }

        return new List<string>();
    }
}

public class BfsNode
{
    public string State { get; }
    public BfsNode? Parent { get; }
    public int Depth { get; }

    public BfsNode(string state, BfsNode? parent = null)
    {
        State = state;
        Parent = parent;
        Depth = parent != null ? parent.Depth + 1 : 0;
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

public class UndirectedGraph
{
    private Dictionary<BfsNode, List<BfsNode>> _adjacencyList = new();

    public void AddNode(BfsNode node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<BfsNode>();
        }

        if (node.Parent != null)
        {
            AddEdge(node, node.Parent);
        }
    }

    public void AddEdge(BfsNode node1, BfsNode node2)
    {
        if (!_adjacencyList.ContainsKey(node1))
        {
            _adjacencyList[node1] = new List<BfsNode>();
        }
        if (!_adjacencyList.ContainsKey(node2))
        {
            _adjacencyList[node2] = new List<BfsNode>();
        }

        _adjacencyList[node1].Add(node2);
        _adjacencyList[node2].Add(node1);
    }

    public List<BfsNode> GetNeighbors(BfsNode node)
    {
        return _adjacencyList.ContainsKey(node) ? _adjacencyList[node] : new List<BfsNode>();
    }
}


/*
Breadth-First Search (BFS) is an uninformed search strategy ideal for situations where all actions have the same cost. 
It systematically explores the search tree level by level, starting from the root node and moving outward, 
ensuring that it finds the solution with the minimum number of actions.

---

Time complexity: O(b^d)
Space complexity: O(b^d)

Where b is the branching factor of the tree and d is the depth of the tree.

---

Example:
In a problem with a branching factor of b = 10 and d = 10.
The number of nodes generated is approximately 10^10. 
At a processing rate of 1 million nodes/second, it would take roughly 3 hours to process, 
and would require a huge amount of memory due to the large number of nodes stored at once.
*/