using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task22Benchmark
{
    [ParamsSource(typeof(Task22Cases), nameof(Task22Cases.Cases))]
    public Task22Cases.PackedPrefixCase Data { get; set; } = null!;

    [Benchmark]
    public string Solve()
    {
        return Task22.Solve(Data.PackedStrings);
    }
}