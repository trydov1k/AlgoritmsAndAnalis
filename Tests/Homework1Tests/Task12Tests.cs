using FluentAssertions;
using HomeWork1;
using HomeWork1.Other;
using NUnit.Framework;

namespace Tests;

public class Task12Tests
{
    [TestCaseSource(typeof(Task12Cases), nameof(Task12Cases.Cases))]
    public void QuickSortInPlace_SortParticipants(Task12Cases.ParticipantCase data)
    {
        var participants = data.Participants.ToArray();

        Task12.QuickSortInPlace(participants);

        var sortedLogins = participants
            .Select(participant => participant.Login)
            .ToArray();

        sortedLogins.Should().Equal(data.ExpectedLogins);
    }
}