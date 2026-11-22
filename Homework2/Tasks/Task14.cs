namespace Homework2.Tasks;

public static class Task14
{
    public static void Solve()
    {
        var name = Console.ReadLine()!;
        var pattern = Console.ReadLine()!;

        Console.WriteLine(Solve(name, pattern) ? "YES" : "NO");
    }

    public static bool Solve(string name, string pattern)
    {
        var matches = new bool[name.Length + 1, pattern.Length + 1];

        // Пустое имя соответствует пустому образцу.
        matches[0, 0] = true;

        // Пустому имени соответствует образец только из звёздочек.
        for (var j = 1; j <= pattern.Length; j++)
            matches[0, j] =
                pattern[j - 1] == '*' && matches[0, j - 1];

        for (var i = 1; i <= name.Length; i++)
        for (var j = 1; j <= pattern.Length; j++)
        {
            var symbol = pattern[j - 1];

            if (symbol == '*')
                matches[i, j] =
                    matches[i, j - 1] ||
                    matches[i - 1, j];
            else if (symbol == '?' || symbol == name[i - 1]) matches[i, j] = matches[i - 1, j - 1];
        }

        return matches[name.Length, pattern.Length];
    }
}