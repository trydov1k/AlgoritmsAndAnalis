using Benchmark.Configs;
using Benchmark.HomeWork1Benchmarks;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;
using Perfolizer.Metrology;

//BenchmarkRunner.Run<SearchBenchmark>();

//BenchmarkRunner.Run<SorterBenchmark>();

// BenchmarkRunner.Run<Task3Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Millisecond,
//     sizeUnit: SizeUnit.MB));

// BenchmarkRunner.Run<Task6Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Microsecond,
//     sizeUnit: null));

// BenchmarkRunner.Run<Task10Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Microsecond,
//     sizeUnit: SizeUnit.B,
//     hideMethods: true));

BenchmarkRunner.Run<Task12Benchmark>(new MyConfig(
    timeUnit: TimeUnit.Microsecond,
    sizeUnit: null,
    hideMethods: true));
    
