namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static void HeapSort<T>(T[] array)
        where T : IComparable
    {
        // Строим кучу с максимальным элементом в корне.
        for (var root = array.Length / 2 - 1; root >= 0; root--)
            SiftDown(array, root, array.Length);

        // Переносим максимальный элемент в конец.
        for (var end = array.Length - 1; end > 0; end--)
        {
            (array[0], array[end]) = (array[end], array[0]);

            SiftDown(array, 0, end);
        }
    }

    private static void SiftDown<T>(
        T[] array,
        int root,
        int heapSize)
        where T : IComparable
    {
        while (true)
        {
            var left = root * 2 + 1;
            var right = root * 2 + 2;
            var largest = root;

            if (left < heapSize &&
                array[left].CompareTo(array[largest]) > 0)
            {
                largest = left;
            }

            if (right < heapSize &&
                array[right].CompareTo(array[largest]) > 0)
            {
                largest = right;
            }

            if (largest == root)
                return;

            (array[root], array[largest]) =
                (array[largest], array[root]);

            root = largest;
        }
    }
}