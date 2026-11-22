using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task19Tests
{
    [TestCaseSource(typeof(Task19Cases), nameof(Task19Cases.Cases))]
    public void Solve_ReturnsNumberOfTriples(
        Task19Cases.PumpingCase data)
    {
        var result = Task19.Solve(data.S, data.T);

        result.Should().Be(data.Expected);
    }
}