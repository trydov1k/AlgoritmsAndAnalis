using Algorithms.Algorithms.Sorters;

namespace HomeWork1;

public static class Task12
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine());

        var participants = new Participant[n];

        for (var i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split(' ');
            var login = line[0];
            var solved = int.Parse(line[1]);
            var penalty = int.Parse(line[2]);

            participants[i] = new Participant(login, solved, penalty);
        }

        Sorters.QuickSortInPlace(participants);

        Console.WriteLine(string.Join(" ", participants));
    }

    private static int Compare(Participant first, Participant second)
    {
        var solvedComparison = second.Solved.CompareTo(first.Solved);
        if (solvedComparison != 0)
            return solvedComparison;

        var penaltyComparison = first.Penalty.CompareTo(second.Penalty);
        if (penaltyComparison != 0)
            return penaltyComparison;

        return string.CompareOrdinal(first.Login, second.Login);
    }

    public sealed class Participant(
        string login,
        int solved,
        int penalty) : IComparable
    {
        public string Login { get; } = login.ToLower();
        public int Solved { get; } = solved;
        public int Penalty { get; } = penalty;
        public int CompareTo(object? obj)
        {
            return Compare(this, obj as Participant);
        }
    }
}