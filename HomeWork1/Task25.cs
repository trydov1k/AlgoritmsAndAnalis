namespace HomeWork1;

public static class Task25
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);

        var values = Console.ReadLine()!
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(Solve(values) ? "YES" : "NO");
    }

    public static bool Solve(int[] values)
    {
        // У элементов начиная с values.Length / 2 детей нет.
        for (var parent = 0; parent < values.Length / 2; parent++)
        {
            var left = parent * 2 + 1;
            var right = parent * 2 + 2;

            if (values[parent] > values[left])
                return false;

            if (right < values.Length &&
                values[parent] > values[right])
            {
                return false;
            }
        }

        return true;
    }
}