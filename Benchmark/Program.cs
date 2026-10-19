using Benchmark.Configs;
using Benchmark.HomeWork1Benchmarks;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;
using Perfolizer.Metrology;

//BenchmarkRunner.Run<SearchBenchmark>();
//BenchmarkRunner.Run<SorterBenchmark>();
BenchmarkRunner.Run<Task3Benchmark>(new MyConfig(
    timeUnit: TimeUnit.Millisecond,
    sizeUnit: SizeUnit.MB));