namespace Algorithms.Algorithms;

public static class Sorter
{
    // Merge sort
    public static void MergeSort(int[] array)
    {
        var buffer = new int[array.Length];
        MergeSort(array, buffer, 0, array.Length - 1);
    }

    private static void MergeSort(int[] array, int[] buffer, int left, int right)
    {
        if (left >= right)
            return;

        var mid = left + (right - left) / 2;

        MergeSort(array, buffer, left, mid);
        MergeSort(array, buffer, mid + 1, right);

        Merge(array, buffer, left, mid, right);
    }

    private static void Merge(int[] array, int[] buffer, int left, int mid, int right)
    {
        var i = left;
        var j = mid + 1;
        var bufferIndex = left;

        while (i <= mid && j <= right)
        {
            if (array[i] <= array[j])
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

    // HeapSort
    public static void HeapSort(int[] arr)
    {
        var n = arr.Length;

        for (var i = n / 2 - 1; i >= 0; i--)
            SiftDown(arr, n, i);

        for (var end = n - 1; end > 0; end--)
        {
            (arr[0], arr[end]) = (arr[end], arr[0]);
            SiftDown(arr, end, 0);
        }
    }

    // Просеивание вниз для max-кучи в массиве arr[0..size-1]
    private static void SiftDown(int[] arr, int size, int index)
    {
        while (true)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;

            if (left < size && arr[left] > arr[largest])
                largest = left;
            if (right < size && arr[right] > arr[largest])
                largest = right;

            if (largest == index) break;

            (arr[largest], arr[index]) = (arr[index], arr[largest]);
            index = largest;
        }
    }
}