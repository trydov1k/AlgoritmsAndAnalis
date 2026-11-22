using System.Globalization;

namespace Homework2.Tasks;

public static class Task16
{
    public static void Solve()
    {
        var input = Console.ReadLine()!
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var n = int.Parse(input[0]);
        var radius = double.Parse(input[1], CultureInfo.InvariantCulture);

        var clients = new Point[n];

        for (var i = 0; i < n; i++)
        {
            var parts = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            clients[i] = new Point(
                double.Parse(parts[0], CultureInfo.InvariantCulture),
                double.Parse(parts[1], CultureInfo.InvariantCulture));
        }

        foreach (var station in Solve(clients, radius))
            Console.WriteLine($"{station.Index} {station.Count}");
    }

    public static Station[] Solve(Point[] clients, double radius)
    {
        var counts = new int[clients.Length];
        var radiusSquared = radius * radius;

        // Каждую пару клиентов проверяем один раз.
        for (var i = 0; i < clients.Length; i++)
        for (var j = i + 1; j < clients.Length; j++)
        {
            var dx = clients[i].X - clients[j].X;
            var dy = clients[i].Y - clients[j].Y;

            if (dx * dx + dy * dy <= radiusSquared)
            {
                counts[i]++;
                counts[j]++;
            }
        }

        var best = new Station[Math.Min(10, clients.Length)];
        var size = 0;

        for (var i = 0; i < clients.Length; i++)
        {
            if (counts[i] == 0)
                continue;

            var station = new Station(i, counts[i]);
            var position = 0;

            // При равных количествах сохраняем меньший индекс раньше:
            // станции рассматриваются в порядке возрастания индексов.
            while (position < size &&
                   best[position].Count >= station.Count)
                position++;

            if (position == best.Length)
                continue;

            if (size < best.Length)
                size++;

            for (var j = size - 1; j > position; j--)
                best[j] = best[j - 1];

            best[position] = station;
        }

        var result = new Station[size];
        Array.Copy(best, result, size);

        return result;
    }

    public readonly record struct Point(double X, double Y);

    public readonly record struct Station(int Index, int Count);
}