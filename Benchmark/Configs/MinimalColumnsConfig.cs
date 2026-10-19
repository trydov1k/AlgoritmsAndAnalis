using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace Benchmark.Configs;

public class MinimalColumnsConfig : ManualConfig
{
    public MinimalColumnsConfig()
    {
        // Столбцы, которые хотим видеть
        AddColumn(TargetMethodColumn.Method);          // Method    
        AddColumn(StatisticColumn.Mean);               // Mean

        // Всё остальное — скрываем
        HideColumns(
            "Gen0", "Gen1", "Gen2", "Alloc Ratio",
            "Error", "StdDev", "Median", "Min", "Max",
            "Q1", "Q3", "IQR", "LowerFence", "UpperFence", "Outliers",
            "Ratio", "RatioSD",
            "Job", "Runtime", "IterationCount", "LaunchCount",
            "WarmupCount", "InvocationCount", "UnrollFactor"
        );
    }
}