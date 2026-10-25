using Algorithms.Algorithms.Sorters;

namespace HomeWork1;

public static class Task16
{
    public static void Solve()
    {
        var input = Console.ReadLine()!
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var n = int.Parse(input[0]);
        var k = uint.Parse(input[1]);
        var m = uint.Parse(input[2]);
        var l = uint.Parse(input[3]);

        Console.WriteLine(Solve(n, k, m, l));
    }

    public static uint Solve(int n, uint k, uint m, uint l)
    {
        var values = GenerateSequence(n, k, m, l);

        Sorters.RadixSort(values);

        return SumOddPositions(values, l);
    }

    private static uint[] GenerateSequence(int n, uint k, uint m, uint l)
    {
        var values = new uint[n];
        values[0] = k;

        for (var i = 1; i < n; i++)
            values[i] = unchecked((uint)((ulong)values[i - 1] * m)) % l;

        return values;
    }

    private static uint SumOddPositions(uint[] values, uint l)
    {
        ulong sum = 0;

        // Нечётные позиции 1, 3, 5 — это индексы 0, 2, 4.
        for (var i = 0; i < values.Length; i += 2)
            sum += values[i];

        return (uint)(sum % l);
    }
}