using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task19Benchmark
{
    [ParamsSource(typeof(Task19Cases), nameof(Task19Cases.Cases))]
    public Task19Cases.PumpingCase Data { get; set; } = null!;

    [Benchmark]
    public long Solve()
    {
        return Task19.Solve(Data.S, Data.T);
    }
}