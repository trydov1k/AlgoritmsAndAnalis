using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task6Tests
{
    [TestCaseSource(typeof(Task6Cases), nameof(Task6Cases.Cases))]
    public void Solve_ReturnsMinimumLargestVolume(
        Task6Cases.NovelCase data)
    {
        var result = Task6.Solve(data.Chapters, data.K);

        result.Should().Be(data.Expected);
    }
}