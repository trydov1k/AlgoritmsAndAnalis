using System.Text;
using Benchmark.Other;
using BenchmarkDotNet.Attributes;
using HomeWork1;

namespace Benchmark.HomeWork1Benchmarks;

public class Task3Benchmark
{
    [Params(
        "0 0", // Пустое множество
        "0 1 20000 0", // Первое пустое
        "1 20000 0 0", // Второе пустое
        "1 3 0 2 4 0", // Нет общих чисел
        "1 2 3 0 1 2 3 0", // Полностью совпадают
        "1 2 3 0 2 3 4 0",
        "20000 1 0 1 0",
        "1 2 3 4 5 6 7 8 0 9 10 11 12 0"
    )]
    public string InputString;
    
    [Benchmark]
    public int[] TestSolve()
    {
        return Task3.Solve(InputString);
    }
    
    // private string _randomInput;
    // 
    // [Params(100, 10_000)] public int LeftArraySize;
    // [Params(1_000, 10_000)] public int RightArraySize;
    // [GlobalSetup]
    // public void Setup()
    // {
    //     var builder = new StringBuilder();
    //     builder.Append(string.Join(' ', TestDataGenerator.CreateUniqueArray(LeftArraySize, seed: 42)));
    //     builder.Append(" 0 ");
    //     builder.Append(string.Join(' ', TestDataGenerator.CreateUniqueArray(RightArraySize, seed: 43)));
    //     builder.Append(" 0");
    //     _randomInput = builder.ToString();
    // }
    // 
    // [Benchmark]
    // public int[] TestSolveOnRandomInput()
    // {
    //     return Task3.Solve(_randomInput);
    // }
}