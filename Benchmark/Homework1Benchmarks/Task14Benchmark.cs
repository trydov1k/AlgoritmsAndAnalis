using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.TestCases;

namespace Benchmark.HomeWork1Benchmarks;

public class Task14Benchmark
{
    [ParamsSource(typeof(Task14Cases), nameof(Task14Cases.Cases))]
    public Task14Cases.EntryCase Data { get; set; } = null!;
    
    private Task14.Entry[] _entries;
    [IterationSetup]
    public void Setup()
    {
        _entries = Data.Entries.ToArray();
    }
    
    [Benchmark]
    public void Solve()
    {
        Task14.Sort(_entries);
    }
}