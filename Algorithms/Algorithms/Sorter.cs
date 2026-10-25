namespace Algorithms.Algorithms;

public static class Sorter
{
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