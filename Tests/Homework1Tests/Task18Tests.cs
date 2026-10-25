using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests.Homework1Tests;

[TestFixture]
public class Task18Tests
{
    [Test]
    [TestCaseSource(typeof(Task18Cases), nameof(Task18Cases.Cases))]
    public void Solve_ReturnsMaximumVisitors(Task18Cases.VisitCase data)
    {
        var result = Task18.Solve(data.Visits);

        result.Should().Be(data.Expected);
    }
}