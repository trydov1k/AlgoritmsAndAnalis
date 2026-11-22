using System.Globalization;

namespace Homework2.Tasks;

public static class Task2
{
    public static void Solve()
    {
        var input = Console.In.ReadToEnd()
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

        var n = int.Parse(input[0]);
        var capitals = new int[n];

        for (var i = 0; i < n; i++)
            capitals[i] = int.Parse(input[i + 1]);

        var result = Solve(capitals);

        Console.WriteLine(result.ToString("F2", CultureInfo.InvariantCulture));
    }

    public static decimal Solve(int[] capitals)
    {
        var queue = new PriorityQueue<long, long>(capitals.Length);

        foreach (var capital in capitals)
            queue.Enqueue(capital, capital);

        long total = 0;

        while (queue.Count > 1)
        {
            var first = queue.Dequeue();
            var second = queue.Dequeue();

            var merged = first + second;
            total += merged;

            queue.Enqueue(merged, merged);
        }

        return total / 100m;
    }
}