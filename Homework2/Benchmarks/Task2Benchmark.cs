using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task2Benchmark
{
    [ParamsSource(typeof(Task2Cases), nameof(Task2Cases.Cases))]
    public Task2Cases.BrokerCase Data { get; set; } = null!;

    [Benchmark]
    public decimal Solve()
    {
        return Task2.Solve(Data.Capitals);
    }
}