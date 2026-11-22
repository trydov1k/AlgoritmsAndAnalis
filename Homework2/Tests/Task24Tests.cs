using FluentAssertions;
using Homework2.Tasks;
using HomeWork2.TestCases;
using NUnit.Framework;

namespace Homework2.Tests;

[TestFixture]
public class Task24Tests
{
    [TestCaseSource(typeof(Task24Cases), nameof(Task24Cases.Cases))]
    public void Solve_ReturnsStrongestSpell(Task24Cases.SpellCase data)
    {
        var result = Task24.Solve(data.Spell);

        result.Should().NotBeNullOrEmpty();
        data.Spell.Should().Contain(result);

        var power = 0;

        for (var i = 0; i <= data.Spell.Length - result.Length; i++)
        {
            if (string.CompareOrdinal(
                    data.Spell, i,
                    result, 0,
                    result.Length) == 0)
            {
                power++;
            }
        }

        power.Should().Be(data.ExpectedPower);
    }
}