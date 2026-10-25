using FluentAssertions;
using HomeWork1;
using HomeWork1.TestCases;
using NUnit.Framework;

namespace Tests;

public class Task14Tests
{
    [Test]
    [TestCaseSource(typeof(Task14Cases), nameof(Task14Cases.Cases))]
    public void Solve_Returns_Sorted(Task14Cases.EntryCase data)
    {
        var result = Task14.Sort(data.Entries.ToArray())
            .Select(entry => entry.Name);

        result.Should().Equal(data.Expected);
    }
}