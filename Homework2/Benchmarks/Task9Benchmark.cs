using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task9Benchmark
{
    [ParamsSource(typeof(Task9Cases), nameof(Task9Cases.Cases))]
    public Task9Cases.PhoneBookCase Data { get; set; } = null!;

    [Benchmark]
    public string[] Solve()
    {
        return Task9.Solve(Data.Commands);
    }
}