namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

public class UniformCostSearch
{
    public static (List<string>, int) FindPath(UcsGraph graph, UcsNode start, string goalState)
    {
        var frontier = new PriorityQueue<UcsNode, int>();
        var reached = new Dictionary<string, int>();
        
        frontier.Enqueue(start, 0);
        reached[start.State] = 0;

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
                var childNode = new UcsNode(edge.Node.State, currentNode, currentNode.PathCost + edge.Cost);
                int newCost = childNode.PathCost;

                if (!reached.ContainsKey(childNode.State) || newCost < reached[childNode.State])
                {
                    reached[childNode.State] = newCost;
                    frontier.Enqueue(childNode, newCost);
                }
            }
        }

        return (new List<string>(), 0);
    }
}

public class UcsNode
{
    public string State { get; }
    public UcsNode? Parent { get; }
    public int PathCost { get; }

    public UcsNode(string state, UcsNode? parent = null, int pathCost = 0)
    {
        State = state;
        Parent = parent;
        PathCost = pathCost;
    }

    public (List<string>, int) GetPath()
    {
        var path = new List<string>();
        var current = this;
        while (current != null)
        {
            path.Add(current.State);
            current = current.Parent;
        }
        
        path.Reverse();
        return (path, this.PathCost);
    }
}

public class UcsEdge
{
    public UcsNode Node { get; }
    public int Cost { get; }

    public UcsEdge(UcsNode node, int cost)
    {
        Node = node;
        Cost = cost;
    }
}

public class UcsGraph
{
    private Dictionary<string, List<UcsEdge>> _adjacencyList = new();

    public void AddEdge(UcsNode fromNode, UcsNode toNode, int cost)
    {
        if (!_adjacencyList.ContainsKey(fromNode.State))
        {
            _adjacencyList[fromNode.State] = new List<UcsEdge>();
        }
        if (!_adjacencyList.ContainsKey(toNode.State))
        {
            _adjacencyList[toNode.State] = new List<UcsEdge>();
        }

        _adjacencyList[fromNode.State].Add(new UcsEdge(toNode, cost));
        _adjacencyList[toNode.State].Add(new UcsEdge(fromNode, cost));
    }

    public List<UcsEdge> GetNeighbors(UcsNode node)
    {
        return _adjacencyList.ContainsKey(node.State) ? _adjacencyList[node.State] : new List<UcsEdge>();
    }
}

/*
Uniform-Cost Search (or Dijkstra’s algorithm) is an uninformed search strategy used when actions have different costs. 
UCS explores nodes in waves of increasing path cost, ensuring that the first path to reach the goal is the least expensive in terms of cumulative cost. 
This makes UCS a cost-optimal and complete algorithm for finding the least-cost path to the goal.

---

Time & Space complexity worst case: O(b^(1+⌊C* / ϵ⌋))
Where:
  - b: The branching factor.
  - C*: The cost of the optimal solution.
  - ϵ: A lower bound on the cost of each action, where ϵ > 0.

This can be much greater than b^d, and this exponential growth occurs because UCS may explore many low-cost nodes 
before encountering nodes on the least-cost path to the goal.

When all action costs are equal, UCS has a time and space complexity of O(b^(d+1))
Where 
  - d is the solution depth.

---
*/