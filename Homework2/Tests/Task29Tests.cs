using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task29Tests
{
    [TestCaseSource(typeof(Task29Cases), nameof(Task29Cases.Cases))]
    public void Solve_ReturnsDistinctSubstringCount(
        Task29Cases.SubstringCase data)
    {
        var result = Task29.Solve(data.Text);

        result.Should().Be(data.Expected);
    }
}