namespace Homework2.Tasks;

public static class Task6
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);

        var chapters = Console.ReadLine()!
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var k = int.Parse(Console.ReadLine()!);

        Console.WriteLine(Solve(chapters, k));
    }

    public static int Solve(int[] chapters, int k)
    {
        var left = chapters.Max();
        var right = chapters.Sum();

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (CanDistribute(chapters, k, middle))
                right = middle;
            else
                left = middle + 1;
        }

        return left;
    }

    private static bool CanDistribute(
        int[] chapters,
        int k,
        int maxPages)
    {
        var volumes = 1;
        var currentPages = 0;

        foreach (var pages in chapters)
            if (currentPages + pages > maxPages)
            {
                volumes++;
                currentPages = pages;

                if (volumes > k)
                    return false;
            }
            else
            {
                currentPages += pages;
            }

        return true;
    }
}