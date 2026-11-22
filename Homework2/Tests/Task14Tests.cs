using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task14Tests
{
    [TestCaseSource(typeof(Task14Cases), nameof(Task14Cases.Cases))]
    public void Solve_ReturnsWhetherPatternMatches(
        Task14Cases.PatternCase data)
    {
        var result = Task14.Solve(data.FileName, data.Pattern);

        result.Should().Be(data.Expected);
    }
}