namespace Algorithms.Algorithms;

public class Searcher
{
    public static int LinearSearch<T>(T[] array, T item)
    {
        for (var i = 0; i < array.Length; i++)
            if (array[i]!.Equals(item))
                return i;
        return -1;
    }
}