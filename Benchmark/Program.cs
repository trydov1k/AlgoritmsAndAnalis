using Benchmark.Configs;
using Benchmark.HomeWork1Benchmarks;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

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

// BenchmarkRunner.Run<Task12Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Microsecond,
//     sizeUnit: null,
//     hideMethods: true));

// BenchmarkRunner.Run<Task14Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Microsecond,
//     sizeUnit: null,
//     hideMethods: true));

// BenchmarkRunner.Run<Task16Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Millisecond,
//     sizeUnit: SizeUnit.MB,
//     hideMethods: true));

// BenchmarkRunner.Run<Task18Benchmark>(new MyConfig(
//     timeUnit: TimeUnit.Microsecond,
//     sizeUnit: null,
//     hideMethods: true));

BenchmarkRunner.Run<Task25Benchmark>(new MyConfig(
    timeUnit: TimeUnit.Microsecond,
    sizeUnit: null,
    hideMethods: true));