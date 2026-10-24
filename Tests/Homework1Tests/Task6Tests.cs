using FluentAssertions;
using HomeWork1;
using HomeWork1.Other;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class Task6Tests
{
    [Test]
    [TestCaseSource(typeof(Task6Cases), nameof(Task6Cases.Cases))]
    public void Solve_StandardsInput_ReturnsStandardOutput(PolynomialCase polynomialCase)
    {
        var result = Task6.Solve(
            polynomialCase.Coefficients,
            polynomialCase.Values,
            polynomialCase.Mod).ToArray();

        result.Should().Equal(polynomialCase.Expected);
    }
}