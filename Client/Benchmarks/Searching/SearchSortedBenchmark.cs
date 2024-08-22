using BenchmarkDotNet.Attributes;

namespace Albin.AlgorithmsAndDataStructures.Client.Benchmarks.Searching;

[MemoryDiagnoser]
public class SearchSortedBenchmark
{
    private int[] _arr = null!;
    private const int Index = 800;

    [GlobalSetup]
    public void Setup()
    {
        _arr = new int[1000];
        for (var i = 0; i < _arr.Length; i++)
        {
            _arr[i] = i + 1;
        }
    }

    [Benchmark]
    public void BinarySearch()
    {
        Core.Algorithms.Searching.BinarySearch.Search((int[])_arr.Clone(), Index);
    }
}
