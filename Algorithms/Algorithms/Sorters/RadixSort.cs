namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static void RadixSort(uint[] values)
    {
        var buffer = new uint[values.Length];
        var counts = new int[1 << 16];

        // Первый проход: из values в buffer по младшим 16 битам.
        SortByDigits(values, buffer, counts, 0);

        // Второй проход: обратно в values по старшим 16 битам.
        SortByDigits(buffer, values, counts, 16);
    }
    
    private static void SortByDigits(
        uint[] source,
        uint[] destination,
        int[] counts,
        int shift)
    {
        Array.Clear(counts, 0, counts.Length);

        CountDigits(source, counts, shift);
        ConvertCountsToPositions(counts);
        DistributeValues(source, destination, counts, shift);
    }

    private static void CountDigits(uint[] values, int[] counts, int shift)
    {
        foreach (var value in values)
        {
            var digit = GetDigit(value, shift);
            counts[digit]++;
        }
    }

    private static void ConvertCountsToPositions(int[] counts)
    {
        var position = 0;

        for (var digit = 0; digit < counts.Length; digit++)
        {
            var count = counts[digit];
            counts[digit] = position;
            position += count;
        }
    }

    private static void DistributeValues(
        uint[] source,
        uint[] destination,
        int[] positions,
        int shift)
    {
        foreach (var value in source)
        {
            var digit = GetDigit(value, shift);

            destination[positions[digit]] = value;
            positions[digit]++;
        }
    }

    private static int GetDigit(uint value, int shift)
    {
        return (int)((value >> shift) & 0xFFFFU);
    }
}