using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task22Tests
{
    [TestCaseSource(typeof(Task22Cases), nameof(Task22Cases.Cases))]
    public void Solve_ReturnsLongestCommonPrefix(
        Task22Cases.PackedPrefixCase data)
    {
        var result = Task22.Solve(data.PackedStrings);

        result.Should().Be(data.Expected);
    }
}