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
        
        for (int t = left; t <= right; t++)
            array[t] = buffer[t];
    }
    
    // Quick sort
    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        while (left < right)
        {

            int randomIndex = Random.Shared.Next(left, right + 1);
            Swap(array, randomIndex, left);

            var (lt, gt) = Partition3Way(array, left, right);

            int leftSize = lt - left;
            int rightSize = right - gt;

            if (leftSize < rightSize)
            {
                QuickSort(array, left, lt - 1);
                left = gt + 1;
            }
            else
            {
                QuickSort(array, gt + 1, right);
                right = lt - 1;
            }
        }
    }

    private static (int lt, int gt) Partition3Way(int[] array, int left, int right)
    {
        var pivot = array[left];
        
        var lt = left;
        var i = left + 1;
        var gt = right;

        while (i <= gt)
        {
            if (array[i] < pivot)
                Swap(array, lt++, i++);
            else if (array[i] > pivot)
                Swap(array, i, gt--);
            else
                i++;
        }
        
        return (lt, gt);
    }

    private static void Swap(int[] array, int i, int j)
    {
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    
    // Counting sort
    public static int[] CountingSort(int[] array, int k)
    {
        int n = array.Length;
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
    
    // HeapSort
    public static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            SiftDown(arr, n, i);

        for (int end = n - 1; end > 0; end--)
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
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

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