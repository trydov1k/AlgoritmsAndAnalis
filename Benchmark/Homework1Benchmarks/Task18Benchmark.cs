using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.TestCases;

namespace Benchmark.HomeWork1Benchmarks;

public class Task18Benchmark
{
    [ParamsSource(typeof(Task18Cases), nameof(Task18Cases.Cases))]
    public Task18Cases.VisitCase Data { get; set; } = null!;

    [Benchmark]
    public int Solve()
    {
        return Task18.Solve(Data.Visits);
    }
}