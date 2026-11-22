using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task16Benchmark
{
    [ParamsSource(typeof(Task16Cases), nameof(Task16Cases.Cases))]
    public Task16Cases.TaxiCase Data { get; set; } = null!;

    [Benchmark]
    public Task16.Station[] Solve()
    {
        return Task16.Solve(Data.Clients, Data.Radius);
    }
}