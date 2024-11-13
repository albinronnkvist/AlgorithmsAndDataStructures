namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

public class BreadthFirstSearch
{
    public static List<string> Execute(UndirectedGraph graph, Node startState, string goalState)
    {
        var frontier = new Queue<Node>();
        frontier.Enqueue(startState);
        var reached = new HashSet<Node> { startState };
        var iterations = 0;

        while (frontier.Count > 0)
        {
            iterations++;
            var currentNode = frontier.Dequeue();

            // Early goal test
            if (currentNode.State.Equals(goalState))
            {
                Console.WriteLine($"Iterations: {iterations}");
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

        Console.WriteLine($"Iterations: {iterations}");
        return new List<string>();
    }
}

public class Node
{
    public string State { get; }
    public Node? Parent { get; }
    public int Depth { get; }

    public Node(string state, Node? parent = null)
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
    private Dictionary<Node, List<Node>> _adjacencyList = new();

    public void AddNode(Node node)
    {
        if (!_adjacencyList.ContainsKey(node))
        {
            _adjacencyList[node] = new List<Node>();
        }

        if (node.Parent != null)
        {
            AddEdge(node, node.Parent);
        }
    }

    public void AddEdge(Node node1, Node node2)
    {
        if (!_adjacencyList.ContainsKey(node1))
        {
            _adjacencyList[node1] = new List<Node>();
        }
        if (!_adjacencyList.ContainsKey(node2))
        {
            _adjacencyList[node2] = new List<Node>();
        }

        _adjacencyList[node1].Add(node2);
        _adjacencyList[node2].Add(node1);
    }

    public List<Node> GetNeighbors(Node node)
    {
        return _adjacencyList.ContainsKey(node) ? _adjacencyList[node] : new List<Node>();
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