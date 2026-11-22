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
        BenchmarkRunner.Run<Task11Benchmark>(new MyConfig(
            timeUnit: TimeUnit.Microsecond,
            sizeUnit: SizeUnit.B,
            hideMethods: true));
    }
}