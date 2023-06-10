using Albin.AlgorithmsAndDataStructures.Client.Benchmarks.Searching;
using BenchmarkDotNet.Running;

namespace Albin.AlgorithmsAndDataStructures.Client;

internal class Program
{
    static void Main(string[] args)
    {
        //BenchmarkRunner.Run<SortBenchmark>();
        BenchmarkRunner.Run<SearchSortedBenchmark>();

        Console.Write("\n\n\n\nEnter any key to exit...");
        Console.ReadKey();
    }
}