using BenchmarkDotNet.Attributes;
using Homework2.Tasks;
using HomeWork2.TestCases;

namespace Homework2.Benchmarks;

public class Task24Benchmark
{
    [ParamsSource(typeof(Task24Cases), nameof(Task24Cases.Cases))]
    public Task24Cases.SpellCase Data { get; set; } = null!;

    [Benchmark]
    public string Solve()
    {
        return Task24.Solve(Data.Spell);
    }
}