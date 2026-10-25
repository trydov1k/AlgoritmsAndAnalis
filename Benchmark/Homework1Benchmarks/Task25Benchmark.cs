using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.TestCases;

namespace Benchmark.HomeWork1Benchmarks;

public class Task25Benchmark
{
    [ParamsSource(typeof(Task25Cases), nameof(Task25Cases.Cases))]
    public Task25Cases.HeapCase Data { get; set; } = null!;

    [Benchmark]
    public bool Solve()
    {
        return Task25.Solve(Data.Values);
    }
}