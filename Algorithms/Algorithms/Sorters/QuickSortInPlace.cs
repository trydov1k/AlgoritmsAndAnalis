namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static void QuickSortInPlace<T>(T[] array)
        where T : IComparable
    {
        QuickSortInPlace(array, 0, array.Length - 1);
    }

    private static void QuickSortInPlace<T>(T[] array, int left, int right)
        where T : IComparable
    {
        while (true)
        {
            if (left >= right) return;
            var pivot = array[(left + right) / 2];

            var lt = left;
            var rt = right;

            while (lt <= rt)
            {
                while (array[lt].CompareTo(pivot) < 0) lt++;

                while (array[rt].CompareTo(pivot) > 0) rt--;

                if (lt <= rt)
                {
                    (array[lt], array[rt]) = (array[rt], array[lt]);
                    lt++;
                    rt--;
                }
            }

            QuickSortInPlace(array, left, rt);
            left = lt;
        }
    }
}