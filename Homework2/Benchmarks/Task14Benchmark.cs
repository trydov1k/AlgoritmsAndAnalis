using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task14Benchmark
{
    [ParamsSource(typeof(Task14Cases), nameof(Task14Cases.Cases))]
    public Task14Cases.PatternCase Data { get; set; } = null!;

    [Benchmark]
    public bool Solve()
    {
        return Task14.Solve(Data.FileName, Data.Pattern);
    }
}