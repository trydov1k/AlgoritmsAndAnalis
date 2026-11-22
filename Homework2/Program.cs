using Benchmark.Configs;
using BenchmarkDotNet.Running;
using Homework2.Benchmarks;
using Perfolizer.Horology;
using Perfolizer.Metrology;

namespace Homework2;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<Task6Benchmark>(new MyConfig(
            timeUnit: TimeUnit.Nanosecond,
            sizeUnit: SizeUnit.B,
            hideMethods: true));
    }
}