using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests.Homework1Tests;

public class Task23Tests
{
    [TestCaseSource(typeof(Task12Cases), nameof(Task12Cases.Cases))]
    public void HeapSort_SortParticipants(Task12Cases.ParticipantCase data)
    {
        var participants = data.Participants.ToArray();

        Task23.Solve(participants);

        var sortedLogins = participants
            .Select(participant => participant.Login)
            .ToArray();

        sortedLogins.Should().Equal(data.ExpectedLogins);
    }
}