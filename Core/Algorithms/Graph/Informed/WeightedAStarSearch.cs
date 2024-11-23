namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph.Informed;

public class WeightedAStarSearch
{
    public static List<string> Execute(AStarGraph graph, AStarNode start, string goalState, Func<string, int> heuristic, double weight)
    {
        var frontier = new PriorityQueue<AStarNode, double>();
        var reached = new Dictionary<string, int>();

        frontier.Enqueue(start, heuristic(start.State) * weight);
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

                    double priority = newCost + heuristic(neighbor.State) * weight;
                    frontier.Enqueue(new AStarNode(neighbor.State, currentNode), priority);
                }
            }
        }

        return new List<string>();
    }
}
