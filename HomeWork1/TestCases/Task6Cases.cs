namespace HomeWork1.TestCases;

public sealed class PolynomialCase(
    string name,
    List<int> coefficients,
    List<int> values,
    int mod,
    List<int> expected)
{
    public List<int> Coefficients { get; } = coefficients;
    public List<int> Values { get; } = values;
    public int Mod { get; } = mod;
    public List<int> Expected { get; } = expected;

    public override string ToString()
    {
        return name;
    }
}

public static class Task6Cases
{
    public static IEnumerable<PolynomialCase> Cases
    {
        get
        {
            yield return new PolynomialCase(
                "Standard1", // 1x² + 5x + 4
                new List<int> { 1, 5, 4 },
                new List<int> { 0, 1, 2, 3, 4 },
                10,
                new List<int> { 4, 0, 8, 8, 0 });

            yield return new PolynomialCase(
                "Standard2",
                new List<int> { 1, 0, 0, 0, 0, 0 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                10,
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            yield return new PolynomialCase(
                "MultipleArguments", // 2x³ + 3x² + 4x + 1
                new List<int> { 2, 3, 4, 1 },
                new List<int> { 0, 1, 2, 3 },
                1000,
                new List<int> { 1, 10, 37, 94 });

            yield return new PolynomialCase(
                "Modulo", // 2x³ + 3x² + 4x + 1
                new List<int> { 2, 3, 4, 1 },
                new List<int> { 0, 1, 2, 3 },
                10,
                new List<int> { 1, 0, 7, 4 });

            yield return new PolynomialCase(
                "ZeroArgument", // 7*0² + 8*0 + 29 => 29 % 10 = 9
                new List<int> { 7, 8, 29 },
                new List<int> { 0 },
                10,
                new List<int> { 9 });

            yield return new PolynomialCase(
                "ZeroCoefficients", // 0x² + 0x + 0 => 0
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 1, 100 },
                10,
                new List<int> { 0, 0, 0 });

            yield return new PolynomialCase(
                "MissingTerm", // 2x³ + 0x² + 4x + 1
                new List<int> { 2, 0, 4, 1 },
                new List<int> { 2, 3 },
                1000,
                new List<int> { 25, 67 });

            yield return new PolynomialCase(
                "RepeatedArguments", // x² + 2x + 3
                new List<int> { 1, 2, 3 },
                new List<int> { 3, 1, 3, 0 },
                100,
                new List<int> { 18, 6, 18, 3 });

            yield return new PolynomialCase(
                "LargeMultiplication", // 100_000x²
                new List<int> { 100_000, 0, 0 },
                new List<int> { 100_000 },
                1_000_000,
                new List<int> { 0 });

            yield return new PolynomialCase(
                "LargeArgument", // x³ + x² + x + 1
                new List<int> { 1, 1, 1, 1 },
                new List<int> { 97_009 },
                97,
                new List<int> { 44 });
        }
    }
}