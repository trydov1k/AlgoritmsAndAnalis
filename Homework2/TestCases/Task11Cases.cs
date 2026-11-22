namespace HomeWork2.TestCases;

public static class Task11Cases
{
    public static IEnumerable<CacheCase> Cases
    {
        get
        {
            yield return new CacheCase(
                "SingleRequest",
                1,
                [42],
                1);

            yield return new CacheCase(
                "RepeatedRequest",
                1,
                [7, 7, 7, 7, 7],
                1);

            yield return new CacheCase(
                "CapacityOne_Alternating",
                1,
                [1, 2, 1, 2, 1, 2],
                6);

            // Новые данные обязаны попасть в кеш.
            yield return new CacheCase(
                "RequestedDataMustBeCached",
                1,
                [1, 2, 1],
                3);

            yield return new CacheCase(
                "AllRequestsFit",
                3,
                [1, 2, 3, 1, 2, 3],
                3);

            yield return new CacheCase(
                "AllRequestsUnique",
                2,
                [1, 2, 3, 4, 5],
                5);

            yield return new CacheCase(
                "EvictFarthestNextUse",
                2,
                [1, 2, 3, 1, 2, 3],
                4);

            // На запросе 3 удаляется 2, поскольку он больше не нужен.
            yield return new CacheCase(
                "EvictNeverUsedAgain",
                2,
                [1, 2, 3, 1, 3],
                3);

            yield return new CacheCase(
                "ClassicSequence",
                3,
                [1, 2, 3, 4, 1, 2, 5, 1, 2, 3, 4, 5],
                7);

            yield return new CacheCase(
                "BoundaryRequestIds",
                2,
                [
                    0, 1_000_000_000_000_000_000L,
                    0, 1_000_000_000_000_000_000L
                ],
                2);

            yield return new CacheCase(
                "MaxCapacity_SingleRequest",
                100_000,
                [0],
                1);

            yield return new CacheCase(
                "MaxRequests_SameId",
                1,
                Enumerable.Repeat(
                    1_000_000_000_000_000_000L, 100_000).ToArray(),
                1);

            yield return new CacheCase(
                "MaxRequests_Alternating",
                1,
                Enumerable.Range(0, 100_000)
                    .Select(i => (long)(i % 2))
                    .ToArray(),
                100_000);

            // Максимальное число различных запросов и размер кеша.
            yield return new CacheCase(
                "MaxRequests_MaxCapacity_Unique",
                100_000,
                Enumerable.Range(0, 100_000)
                    .Select(i => (long)i)
                    .ToArray(),
                100_000);

            // 50 000 различных данных запрашиваются дважды.
            yield return new CacheCase(
                "MaxRequests_RepeatedHalf",
                50_000,
                Enumerable.Range(0, 100_000)
                    .Select(i => (long)(i % 50_000))
                    .ToArray(),
                50_000);
        }
    }

    public sealed class CacheCase(
        string name,
        int capacity,
        long[] requests,
        int expected)
    {
        public int Capacity { get; } = capacity;
        public long[] Requests { get; } = requests;
        public int Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}