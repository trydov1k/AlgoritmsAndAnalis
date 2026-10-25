using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.TestCases;

namespace Benchmark.HomeWork1Benchmarks;

public class Task10Benchmark
{
    [ParamsSource(typeof(Task10Cases), nameof(Task10Cases.Cases))]
    public TeamCase Data { get; set; } = null!;

    [Benchmark]
    public List<int> Solve()
    {
        return Task10.Solve(Data.N, Data.K, Data.Friends);
    }
}