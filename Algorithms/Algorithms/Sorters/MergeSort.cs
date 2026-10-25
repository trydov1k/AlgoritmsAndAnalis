namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static void MergeSort<T>(T[] array)
        where T : IComparable
    {
        var buffer = new T[array.Length];
        MergeSort(array, buffer, 0, array.Length - 1);
    }

    private static void MergeSort<T>(T[] array, T[] buffer, int left, int right)
        where T : IComparable
    {
        if (left >= right)
            return;

        var mid = left + (right - left) / 2;

        MergeSort(array, buffer, left, mid);
        MergeSort(array, buffer, mid + 1, right);

        Merge(array, buffer, left, mid, right);
    }

    private static void Merge<T>(T[] array, T[] buffer, int left, int mid, int right)
        where T : IComparable
    {
        var i = left;
        var j = mid + 1;
        var bufferIndex = left;

        while (i <= mid && j <= right)
        {
            if (array[i].CompareTo(array[j]) <= 0)
            {
                buffer[bufferIndex] = array[i];
                i++;
            }
            else
            {
                buffer[bufferIndex] = array[j];
                j++;
            }

            bufferIndex++;
        }

        while (i <= mid)
        {
            buffer[bufferIndex] = array[i];
            i++;
            bufferIndex++;
        }

        while (j <= right)
        {
            buffer[bufferIndex] = array[j];
            j++;
            bufferIndex++;
        }

        for (var t = left; t <= right; t++)
            array[t] = buffer[t];
    }
}