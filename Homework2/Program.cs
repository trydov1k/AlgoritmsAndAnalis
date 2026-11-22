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
        // BenchmarkRunner.Run<Task22Benchmark>(new MyConfig(
        //     timeUnit: TimeUnit.Microsecond,
        //     sizeUnit: SizeUnit.B,
        //     hideMethods: true,
        //     launchCount: 1,
        //     warmupCount: 1,
        //     iterationCount: 3));
        
        BenchmarkRunner.Run<Task24Benchmark>(new MyConfig(
            timeUnit: TimeUnit.Nanosecond,
            sizeUnit: SizeUnit.B,
            hideMethods: true,
            launchCount: 1,
            warmupCount: 1,
            iterationCount: 3));
        
        // BenchmarkRunner.Run<Task29Benchmark>(new MyConfig(
        //     timeUnit: TimeUnit.Microsecond,
        //     sizeUnit: SizeUnit.B,
        //     hideMethods: true,
        //     launchCount: 1,
        //     warmupCount: 1,
        //     iterationCount: 3));
    }
}