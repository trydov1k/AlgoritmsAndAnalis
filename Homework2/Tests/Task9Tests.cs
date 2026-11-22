using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task9Tests
{
    [TestCaseSource(typeof(Task9Cases), nameof(Task9Cases.Cases))]
    public void Solve_ReturnsExpectedProtocol(
        Task9Cases.PhoneBookCase data)
    {
        var result = Task9.Solve(data.Commands);

        result.Should().Equal(data.Expected);
    }
}