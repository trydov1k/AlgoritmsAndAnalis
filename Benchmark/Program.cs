using Benchmark.Configs;
using Benchmark.HomeWork1Benchmarks;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

BenchmarkRunner.Run<Task25Benchmark>(new MyConfig(
    timeUnit: TimeUnit.Microsecond,
    sizeUnit: null,
    hideMethods: true));