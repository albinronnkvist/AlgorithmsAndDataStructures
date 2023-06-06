using BenchmarkDotNet.Attributes;

namespace Albin.AlgorithmsAndDataStructures.Client.Benchmarks.Sorting;

[MemoryDiagnoser]
public class SortBenchmark
{
    private int[] _arr = null!;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        _arr = new int[1000];
        for (var i = 0; i < _arr.Length; i++)
        {
            _arr[i] = random.Next();
        }
    }

    [Benchmark]
    public void BubbleSort()
    {
        Core.Sorting.BubbleSort.Sort((int[])_arr.Clone());
    }

    [Benchmark]
    public void InsertionSort()
    {
        Core.Sorting.InsertionSort.Sort((int[])_arr.Clone());
    }
}
