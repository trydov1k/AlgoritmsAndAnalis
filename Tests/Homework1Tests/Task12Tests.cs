using Algorithms.Algorithms.Sorters;
using FluentAssertions;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests.Homework1Tests;

public class Task12Tests
{
    [TestCaseSource(typeof(Task12Cases), nameof(Task12Cases.Cases))]
    public void QuickSortInPlace_SortParticipants(Task12Cases.ParticipantCase data)
    {
        var participants = data.Participants.ToArray();

        Sorters.QuickSortInPlace(participants);

        var sortedLogins = participants
            .Select(participant => participant.Login)
            .ToArray();

        sortedLogins.Should().Equal(data.ExpectedLogins);
    }
}