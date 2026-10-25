namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static int[] CountingSort(int[] array, int k)
    {
        var n = array.Length;
        var cnt = new int[k];

        foreach (var i in array)
            cnt[i]++;

        for (var i = 1; i < k; i++)
            cnt[i] += cnt[i - 1];

        var outArray = new int[n];
        for (var i = n - 1; i >= 0; i--)
            outArray[--cnt[array[i]]] = array[i];

        return outArray;
    }
}