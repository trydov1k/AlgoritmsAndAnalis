using Algorithms.Algorithms;

namespace HomeWork1;

public static class Task3
{
    public static int[] Solve(string input)
    {
        var strArr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var i = 0;

        var set = new Algorithms.Structures.HashSet<int>();

        while (i < strArr.Length && strArr[i] != "0")
            set.Add(int.Parse(strArr[i++]));
        i++;
        while (i < strArr.Length && strArr[i] != "0")
        {
            var num = int.Parse(strArr[i++]);
            if (!set.Add(num)) set.Remove(num);
        }

        var result = Sorter.CountingSort(set.ToArray(), 20001);

        return result;
    }
}