using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task6Benchmark
{
    [ParamsSource(typeof(Task6Cases), nameof(Task6Cases.Cases))]
    public Task6Cases.NovelCase Data { get; set; } = null!;

    [Benchmark]
    public int Solve()
    {
        return Task6.Solve(Data.Chapters, Data.K);
    }
}