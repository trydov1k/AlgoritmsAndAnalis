namespace Homework2.Tasks;

public static class Task19
{
    public static void Solve()
    {
        Console.ReadLine();

        var s = Console.ReadLine()!;
        var t = Console.ReadLine()!;

        Console.WriteLine(Solve(s, t));
    }

    public static long Solve(string s, string t)
    {
        var difference = t.Length - s.Length;

        var prefix = 0;

        while (prefix < s.Length && s[prefix] == t[prefix])
            prefix++;

        var suffix = 0;

        while (suffix < s.Length &&
               s[s.Length - 1 - suffix] ==
               t[t.Length - 1 - suffix])
            suffix++;

        var firstStart = s.Length - suffix;
        var maxLength = prefix - firstStart;

        long result = 0;

        for (var length = 1; length <= maxLength; length++)
        {
            // Дополнительная часть должна состоять из целых копий y.
            if (difference % length != 0)
                continue;

            var lastStart = prefix - length;

            // Проверяем крайнее правое положение y.
            if (IsRepeated(t, lastStart, length, difference))
                result += lastStart - firstStart + 1;
        }

        return result;
    }

    private static bool IsRepeated(
        string text,
        int start,
        int length,
        int difference)
    {
        // Весь проверяемый участок имеет длину length + difference.
        // Сравниваем его символы со сдвигом на length.
        for (var offset = 0; offset < difference; offset++)
            if (text[start + offset] !=
                text[start + offset + length])
                return false;

        return true;
    }
}