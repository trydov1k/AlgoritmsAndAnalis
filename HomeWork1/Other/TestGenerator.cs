namespace Benchmark.Other;

public static class TestDataGenerator
{
    public static int[] CreateUniqueArray(
        int length,
        int minValue = 1,
        int maxValue = 20000,
        int? seed = null)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length));

        if (minValue > maxValue)
            throw new ArgumentException("Неверный диапазон.");

        var rangeSize = (long)maxValue - minValue + 1;

        if (length > rangeSize)
            throw new ArgumentException(
                "В диапазоне недостаточно уникальных чисел.");

        var random = seed.HasValue
            ? new Random(seed.Value)
            : Random.Shared;

        var set = new HashSet<int>();

        while (set.Count < length)
        {
            var number = (int)random.NextInt64(
                minValue, (long)maxValue + 1);

            set.Add(number);
        }

        return set.ToArray();
    }
}