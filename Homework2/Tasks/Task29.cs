namespace Homework2.Tasks;

public static class Task29
{
    public static void Solve()
    {
        var text = Console.ReadLine()!;

        Console.WriteLine(Solve(text));
    }

    public static int Solve(string text)
    {
        // Переиспользуем массив для всех суффиксов.
        var z = new int[text.Length];
        var result = 0;

        for (var start = 0; start < text.Length; start++)
        {
            var maxMatch = FindLongestRepeatedPrefix(text, start, z);

            result += text.Length - start - maxMatch;
        }

        return result;
    }

    private static int FindLongestRepeatedPrefix(
        string text,
        int start,
        int[] z)
    {
        var length = text.Length - start;

        var left = 0;
        var right = 0;
        var maxMatch = 0;

        // Индексы i, left и right относятся к текущему суффиксу.
        for (var i = 1; i < length; i++)
        {
            z[i] = 0;

            if (i < right)
                z[i] = Math.Min(right - i, z[i - left]);

            while (i + z[i] < length &&
                   text[start + z[i]] == text[start + i + z[i]])
            {
                z[i]++;
            }

            if (i + z[i] > right)
            {
                left = i;
                right = i + z[i];
            }

            maxMatch = Math.Max(maxMatch, z[i]);
        }

        return maxMatch;
    }
}