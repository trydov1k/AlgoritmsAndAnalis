using BenchmarkDotNet.Attributes;
using HomeWork1;
using HomeWork1.Other;

namespace Benchmark.HomeWork1Benchmarks;

public class Task12Benchmark
{
    [ParamsSource(typeof(Task12Cases), nameof(Task12Cases.Cases))]
    public Task12Cases.ParticipantCase Data { get; set; } = null!;
    
    private Task12.Participant[] participants;

    [IterationSetup]
    public void Setup()
    {
        participants = Data.Participants.ToArray();
    }
    
    [Benchmark]
    public void Solve()
    {
        Task12.QuickSortInPlace(participants);
    }
}