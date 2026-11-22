using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task11Benchmark
{
    [ParamsSource(typeof(Task11Cases), nameof(Task11Cases.Cases))]
    public Task11Cases.CacheCase Data { get; set; } = null!;

    [Benchmark]
    public int Solve()
    {
        return Task11.Solve(Data.Capacity, Data.Requests);
    }
}