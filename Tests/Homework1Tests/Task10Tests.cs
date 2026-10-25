using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests;

public class Task10Tests
{
    [TestCaseSource(typeof(Task10Cases), nameof(Task10Cases.Cases))]
    public void Solve_ReturnsOptimalTeam(TeamCase data)
    {
        var result = Task10.Solve(data.N, data.K, data.Friends);

        result.Should().HaveCount(data.K);
        result.Should().OnlyHaveUniqueItems();
        result.Should().OnlyContain(player => player >= 1 && player <= data.N);

        var firstTeam = result.ToHashSet();

        // Оба знакомых находятся в одной команде:
        // либо оба входят в первую, либо оба не входят.
        var cohesion = data.Friends.Count(pair =>
            firstTeam.Contains(pair.Item1) ==
            firstTeam.Contains(pair.Item2));

        cohesion.Should().Be(data.ExpectedCohesion);
    }
}