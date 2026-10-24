using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.Other;

namespace Benchmark.HomeWork1Benchmarks;

public class Task6Benchmark
{
    [ParamsSource(typeof(Task6Cases), nameof(Task6Cases.Cases))]
    public PolynomialCase Data { get; set; } = null!;

    [Benchmark]
    public int[] Solve()
    {
        return Task6.Solve(
            Data.Coefficients,
            Data.Values,
            Data.Mod).ToArray();
    }
}