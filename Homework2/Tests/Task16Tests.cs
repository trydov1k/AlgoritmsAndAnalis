using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task16Tests
{
    [TestCaseSource(typeof(Task16Cases), nameof(Task16Cases.Cases))]
    public void Solve_ReturnsBestStations(Task16Cases.TaxiCase data)
    {
        var result = Task16.Solve(data.Clients, data.Radius);

        result.Should().Equal(data.Expected);
    }
}