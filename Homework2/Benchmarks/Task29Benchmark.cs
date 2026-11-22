using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task29Benchmark
{
    [ParamsSource(typeof(Task29Cases), nameof(Task29Cases.Cases))]
    public Task29Cases.SubstringCase Data { get; set; } = null!;

    [Benchmark]
    public int Solve()
    {
        return Task29.Solve(Data.Text);
    }
}