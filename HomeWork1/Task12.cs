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

        QuickSortInPlace(participants);

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


    public static void QuickSortInPlace(Participant[] array)
    {
        QuickSortInPlace(array, 0, array.Length - 1);
    }

    private static void QuickSortInPlace(Participant[] array, int left, int right)
    {
        while (true)
        {
            if (left >= right) return;
            var pivot = array[(left + right) / 2];

            var lt = left;
            var rt = right;

            while (lt <= rt)
            {
                while (Compare(array[lt], pivot) < 0) lt++;

                while (Compare(array[rt], pivot) > 0) rt--;

                if (lt <= rt)
                {
                    (array[lt], array[rt]) = (array[rt], array[lt]);
                    lt++;
                    rt--;
                }
            }

            QuickSortInPlace(array, left, rt);
            left = lt;
        }
    }

    public sealed class Participant(
        string login,
        int solved,
        int penalty)
    {
        public string Login { get; } = login.ToLower();
        public int Solved { get; } = solved;
        public int Penalty { get; } = penalty;
    }
}