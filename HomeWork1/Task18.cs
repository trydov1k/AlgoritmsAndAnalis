namespace HomeWork1;

public class Task18
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var visits = new (int Arrival, int Departure)[n];

        for (var i = 0; i < n; i++)
        {
            var parts = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            visits[i] = (ToMinutes(parts[0]), ToMinutes(parts[1]));
        }

        Console.WriteLine(Solve(visits));
    }

    public static int Solve((int Arrival, int Departure)[] visits)
    {
        const int minutesPerDay = 24 * 60;
        var changes = new int[minutesPerDay + 1];

        foreach (var (arrival, departure) in visits)
        {
            changes[arrival]++;

            // Посетитель учитывается и в минуту ухода.
            changes[departure + 1]--;
        }

        var current = 0;
        var maximum = 0;

        for (var minute = 0; minute < minutesPerDay; minute++)
        {
            current += changes[minute];
            maximum = Math.Max(maximum, current);
        }

        return maximum;
    }

    private static int ToMinutes(string time)
    {
        var parts = time.Split(':');

        return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
    }
}