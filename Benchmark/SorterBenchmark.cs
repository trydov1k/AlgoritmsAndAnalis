using Algorithms.Algorithms;
using Benchmark.Configs;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Declared)]
[Config(typeof(MinimalColumnsConfig))]
[RankColumn]
public class SorterBenchmark
{
    private int[] _array;
    private int maxValue;
    [Params(100)]
    public int Size;
    
    [GlobalSetup]
    public void Setup()
    {
        _array = new int[Size];
        var rnd = new Random(42);
        for (int i = 0; i < Size; i++)
        {
            var rndValue = rnd.Next(Size - 10);
            if (rndValue > maxValue)
                maxValue = rndValue;
            _array[i] = rndValue;
        }
    }

    [Benchmark]
    public void MergeSort()
    {
        Sorter.MergeSort(_array);
    }

    [Benchmark]
    public void QuickSort()
    {
        Sorter.QuickSort(_array);
    }

    [Benchmark]
    public void CountingSort()
    {
        Sorter.CountingSort(_array, maxValue+1);
    }
}