namespace HomeWork1.Other;

public sealed class PolynomialCase(string name, List<int> coefficients,
    List<int> values, int mod, List<int> expected)
{
    public List<int> Coefficients { get; } = coefficients;
    public List<int> Values { get; } = values;
    public int Mod { get; } = mod;
    public List<int> Expected { get; } = expected;

    public override string ToString() => name;
}
public static class Task6Cases
{
    public static IEnumerable<PolynomialCase> Cases
    {
        get
        {
            yield return new (
                "Standard1",  // 1x² + 5x + 4
                new () { 1, 5, 4 },
                new() { 0, 1, 2, 3, 4 },
                10,
                new () { 4, 0, 8, 8, 0 });
            
            yield return new (
                "Standard2",
                new () { 1, 0, 0, 0, 0, 0 },
                new () { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                10,
                new () { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            
            yield return new(
                "MultipleArguments",  // 2x³ + 3x² + 4x + 1
                new() { 2, 3, 4, 1 },
                new() { 0, 1, 2, 3 },
                1000,
                new() { 1, 10, 37, 94 });
            
            yield return new(
                "Modulo",  // 2x³ + 3x² + 4x + 1
                new() { 2, 3, 4, 1 },
                new() { 0, 1, 2, 3 },
                10,
                new () { 1, 0, 7, 4 });
            
            yield return new(
                "ZeroArgument",  // 7*0² + 8*0 + 29 => 29 % 10 = 9
                new() { 7, 8, 29 },
                new() { 0 },
                10,
                new() { 9 });
            
            yield return new(
                "ZeroCoefficients",  // 0x² + 0x + 0 => 0
                new() { 0, 0, 0 },
                new() { 0, 1, 100 },
                10,
                new() { 0, 0, 0 });
            
            yield return new(
                "MissingTerm",  // 2x³ + 0x² + 4x + 1
                new() { 2, 0, 4, 1 },
                new() { 2, 3 },
                1000,
                new() { 25, 67 });
            
            yield return new(
                "RepeatedArguments",  // x² + 2x + 3
                new() { 1, 2, 3 },
                new() { 3, 1, 3, 0 },
                100,
                new() { 18, 6, 18, 3 });
            
            yield return new(
                "LargeMultiplication",  // 100_000x²
                new() { 100_000, 0, 0 },
                new() { 100_000 },
                1_000_000,
                new() { 0 });
            
            yield return new(
                "LargeArgument",  // x³ + x² + x + 1
                new() { 1, 1, 1, 1 },
                new() { 97_009 },
                97,
                new() { 44 });
        }
    }
}