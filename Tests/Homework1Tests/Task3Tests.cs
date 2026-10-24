using Benchmark.Other;
using HomeWork1;

namespace Tests;

public class Task3Tests
{
    [Theory]
    [InlineData("0 0", "0")] // Пустое множество
    [InlineData("0 1 20000 0", "1 20000")] // Первое пустое
    [InlineData("1 20000 0 0", "1 20000")] // Второе пустое
    [InlineData("1 3 0 2 4 0", "1 2 3 4")] // Нет общих чисел
    [InlineData("1 2 3 0 1 2 3 0", "0")] // Совпадают
    [InlineData("1 2 3 0 2 3 4 0", "1 4")] // Обычный случай
    [InlineData("20000 1 0 1 0", "20000")] // Обычный случай
    [InlineData("1 2 3 4 5 6 7 8 0 9 10 11 12 0", "1 2 3 4 5 6 7 8 9 10 11 12")] // Обычный случай
    public void Solve_ReturnsExpectedResult(string input, string expected)
    {
        var result = Task3.Solve(input);

        var actual = result.Length == 0
            ? "0"
            : string.Join(" ", result);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(100, 100)]
    [InlineData(10, 100)]
    [InlineData(100, 1000)]
    [InlineData(1000, 1000)]
    [InlineData(1000, 10)]
    [InlineData(10000, 10000)]
    public void Solve_OnRandomSets_ReturnsExpectedResult(int leftArrayLength, int rightArrayLength)
    {
        var a = TestDataGenerator.CreateUniqueArray(leftArrayLength, seed: 42);
        var b = TestDataGenerator.CreateUniqueArray(rightArrayLength, seed: 43);

        var input = $"{string.Join(' ', a)} 0 {string.Join(' ', b)} 0";

        var expected = a.Except(b)
            .Concat(b.Except(a))
            .OrderBy(x => x)
            .ToArray();

        var actual = Task3.Solve(input);

        Assert.Equal(expected, actual);
    }
}