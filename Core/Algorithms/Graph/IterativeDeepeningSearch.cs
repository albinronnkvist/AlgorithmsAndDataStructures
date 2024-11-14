namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Graph;

public class IterativeDeepeningSearch
{
    public static List<string> Execute(DlsGraph graph, DlsNode start, string goalState, int maxDepth)
    {
        for (int depth = 0; depth <= maxDepth; depth++)
        {
            var path = DepthLimitedSearch.Execute(graph, start, goalState, depth);
            if (path.Any())
            {
                return path;
            }
        }
        
        return new List<string>();
    }
}
