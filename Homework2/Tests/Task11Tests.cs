using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task11Tests
{
    [TestCaseSource(typeof(Task11Cases), nameof(Task11Cases.Cases))]
    public void Solve_ReturnsMinimumMisses(Task11Cases.CacheCase data)
    {
        var result = Task11.Solve(data.Capacity, data.Requests);

        result.Should().Be(data.Expected);
    }
}