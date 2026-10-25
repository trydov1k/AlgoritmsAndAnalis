using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests.Homework1Tests;

[TestFixture]
public class Task16Tests
{
    [Test, TestCaseSource(typeof(Task16Cases), nameof(Task16Cases.Cases))]
    public void Solve_ReturnsExpectedSum(Task16Cases.SequenceCase data)
    {
        var result = Task16.Solve(
            data.N,
            data.K,
            data.M,
            data.L);

        result.Should().Be(data.Expected);
    }
}