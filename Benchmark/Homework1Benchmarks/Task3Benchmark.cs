using System.Text;
using Benchmark.Other;
using BenchmarkDotNet.Attributes;
using HomeWork1;

namespace Benchmark.HomeWork1Benchmarks;

public class Task3Benchmark
{
    private string _input;
    [Params(100, 1_000, 10_000)] 
    public int LeftArraySize;
    [Params(100, 1_000, 10_000)]
    public int RightArraySize;

    [GlobalSetup]
    public void Setup()
    {
        var builder = new StringBuilder();
        builder.Append(string.Join(' ', TestDataGenerator.CreateUniqueArray(LeftArraySize, seed: 42)));
        builder.Append(" 0 ");
        builder.Append(string.Join(' ', TestDataGenerator.CreateUniqueArray(RightArraySize, seed: 43)));
        builder.Append(" 0");
        _input = builder.ToString();
    }

    [Benchmark]
    public int[] TestSolve() => Task3.Solve(_input);
}