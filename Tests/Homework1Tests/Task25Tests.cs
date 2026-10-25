using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests.Homework1Tests;

public class Task25Tests
{
    [TestCaseSource(typeof(Task25Cases), nameof(Task25Cases.Cases))]
    public void Solve_ReturnsWhetherArrayIsHeap(Task25Cases.HeapCase data)
    {
        var result = Task25.Solve(data.Values);

        result.Should().Be(data.Expected);
    }
}