using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.TestCases;

namespace Benchmark.HomeWork1Benchmarks;

public class Task16Benchmark
{
    [ParamsSource(typeof(Task16Cases), nameof(Task16Cases.BenchmarkCases))]
    public Task16Cases.SequenceCase Data { get; set; } = null!;

    [Benchmark]
    public uint Solve()
    {
        return Task16.Solve(
            Data.N,
            Data.K,
            Data.M,
            Data.L);
    }
}