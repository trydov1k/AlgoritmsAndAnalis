using System.Globalization;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;
using Perfolizer.Metrology;

namespace Benchmark.Configs;

public class MyConfig : ManualConfig
{
    public MyConfig()
        : this(
            true)
    {
    }

    public MyConfig(
        bool memoryDiagnoser = true,
        bool rankColumn = false,
        SummaryOrderPolicy orderPolicy = SummaryOrderPolicy.Declared,
        TimeUnit? timeUnit = null,
        SizeUnit? sizeUnit = null,
        int? launchCount = null,
        int? warmupCount = null,
        int? iterationCount = null)
    {
        AddLogger(ConsoleLogger.Default);

        // Столбцы, которые хотим видеть
        AddColumn(TargetMethodColumn.Method); // Method    
        AddColumn(StatisticColumn.Mean); // Mean

        AddColumnProvider(
            DefaultColumnProviders.Params,
            DefaultColumnProviders.Metrics
        );

        // Всё остальное — скрываем
        HideColumns(
            "Gen0", "Gen1", "Gen2", "Alloc Ratio",
            "Error", "StdDev", "Median", "Min", "Max",
            "Q1", "Q3", "IQR", "LowerFence", "UpperFence", "Outliers",
            "Ratio", "RatioSD",
            "Job", "Runtime", "IterationCount", "LaunchCount",
            "WarmupCount", "InvocationCount", "UnrollFactor"
        );

        if (memoryDiagnoser)
            AddDiagnoser(MemoryDiagnoser.Default);

        if (rankColumn)
            AddColumn(RankColumn.Arabic);

        WithOrderer(new DefaultOrderer(orderPolicy));

        var style = new SummaryStyle(
            CultureInfo.CurrentCulture,
            true,
            sizeUnit,
            timeUnit,
            false
        );

        WithSummaryStyle(style);

        var job = Job.Default;

        if (launchCount is int launches)
            job = job.WithLaunchCount(launches);

        if (warmupCount is int warmups)
            job = job.WithWarmupCount(warmups);

        if (iterationCount is int iterations)
            job = job.WithIterationCount(iterations);

        AddJob(job);

        AddExporter(MarkdownExporter.GitHub);
    }
}