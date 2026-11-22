namespace Homework2.Tasks;

public static class Task24
{
    public static void Solve()
    {
        var spell = Console.ReadLine()!;

        Console.WriteLine(Solve(spell));
    }

    public static string Solve(string spell)
    {
        var counts = new int[26];

        foreach (var letter in spell)
            counts[letter - 'a']++;

        var best = 0;

        for (var i = 1; i < counts.Length; i++)
        {
            if (counts[i] > counts[best])
                best = i;
        }

        return ((char)('a' + best)).ToString();
    }
}