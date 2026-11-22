using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task2Tests
{
    [TestCaseSource(typeof(Task2Cases), nameof(Task2Cases.Cases))]
    public void Solve_ReturnsMinimumCommission(Task2Cases.BrokerCase data)
    {
        var result = Task2.Solve(data.Capitals);

        result.Should().Be(data.Expected);
    }
}