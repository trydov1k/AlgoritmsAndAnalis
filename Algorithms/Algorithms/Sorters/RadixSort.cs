namespace Algorithms.Algorithms.Sorters;

public static partial class Sorters
{
    public static void RadixSort(uint[] values)
    {
        var buffer = new uint[values.Length];
        var counts = new int[1 << 16];

        CountingSort(values, buffer, counts, 0);
        CountingSort(buffer, values, counts, 16);
    }

    private static void CountingSort(
        uint[] source,
        uint[] destination,
        int[] counts,
        int shift)
    {
        const uint mask = 0xFFFFU;

        Array.Clear(counts, 0, counts.Length);

        // Считаем количество элементов в каждой группе.
        foreach (var value in source)
        {
            var digit = (int)((value >> shift) & mask);
            counts[digit]++;
        }

        // Преобразуем количества в начальные позиции групп.
        var position = 0;

        for (var digit = 0; digit < counts.Length; digit++)
        {
            var count = counts[digit];
            counts[digit] = position;
            position += count;
        }

        // Раскладываем элементы, сохраняя порядок внутри групп.
        foreach (var value in source)
        {
            var digit = (int)((value >> shift) & mask);
            destination[counts[digit]++] = value;
        }
    }
}