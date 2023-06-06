using BenchmarkDotNet.Running;
using SortBenchmark = Albin.AlgorithmsAndDataStructures.Client.Benchmarks.Sorting.SortBenchmark;

namespace Albin.AlgorithmsAndDataStructures.Client;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<SortBenchmark>();

        Console.Write("\n\n\n\nEnter any key to exit...");
        Console.ReadKey();
    }
}