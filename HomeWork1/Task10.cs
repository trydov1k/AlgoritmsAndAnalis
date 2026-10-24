using System.Numerics;

namespace HomeWork1;

public static class Task10
{
    public static void Solve()
    {
        var firstLine = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        var n = firstLine[0];
        var k = firstLine[1];
        var m = firstLine[2];

        var friends = new List<(int, int)>();

        for (var i = 0; i < m; i++)
        {
            var pair = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            friends.Add((pair[0], pair[1]));
        }

        Console.WriteLine(string.Join(" ",
            Solve(n, k, friends)));
    }

    public static List<int> Solve(int n, int k, List<(int, int)> friends)
    {
        var minCrossFriendships = int.MaxValue;
        var bestTeamMask = 0;

        for (var teamMask = 0; teamMask < 1 << n; teamMask++)
        {
            if (BitOperations.PopCount((uint)teamMask) != k)
                continue; // Если установлено не ровно k битов — пропустить маску.

            var crossFriendshipsCount =
                CountCrossTeamFriendships(teamMask, friends); // Иначе посчитать знакомства между командами.

            if (crossFriendshipsCount <
                minCrossFriendships) // Если их меньше, чем в лучшем варианте, — запомнить маску.
            {
                minCrossFriendships = crossFriendshipsCount;
                bestTeamMask = teamMask;
            }

            if (minCrossFriendships == 0) // Ноль — минимально возможное значение, поэтому можно закончить
                break;
        }

        var result = new List<int>();

        for (var teamMemberNumber = 1; teamMemberNumber <= n; teamMemberNumber++)
            if ((bestTeamMask & PlayerNumberToFlag(teamMemberNumber)) != 0)
                result.Add(teamMemberNumber);

        return result;
    }

    private static int PlayerNumberToFlag(int playerNumber)
    {
        return 1 << (playerNumber - 1);
    }

    private static int CountCrossTeamFriendships(
        int teamMask, List<(int, int)> friends)
    {
        var count = 0;

        foreach (var pair in friends)
        {
            var firstInTeam =
                (teamMask & PlayerNumberToFlag(pair.Item1)) != 0;

            var secondInTeam =
                (teamMask & PlayerNumberToFlag(pair.Item2)) != 0;

            if (firstInTeam != secondInTeam)
                count++;
        }

        return count;
    }
}