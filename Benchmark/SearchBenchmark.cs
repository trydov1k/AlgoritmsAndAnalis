using Algorithms.Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SearchBenchmark
{
    private static readonly Searcher Searcher = new Searcher();
    private int[] _array;
    private int _numberToSearch;

    [Params(10, 100)] 
    public int Size;

    [GlobalSetup]
    public void Setup()
    {
        _array = new int[Size];
        _numberToSearch = Size;
        for (var i = 0; i < Size; i++)
            _array[i] = i;
    }

    [Benchmark(Baseline = true)]
    public void LinearSearch()
    {
        Searcher.LinearSearch(_array, _numberToSearch);
    }
}