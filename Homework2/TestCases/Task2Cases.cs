namespace HomeWork2.TestCases;

public static class Task2Cases
{
    public static IEnumerable<BrokerCase> Cases
    {
        get
        {
            yield return new BrokerCase(
                "TwoMinimumCapitals",
                [1, 1],
                0.02m);

            yield return new BrokerCase(
                "TwoMaximumCapitals",
                [1_000_000, 1_000_000],
                20_000m);

            yield return new BrokerCase(
                "ThreeEqualCapitals",
                [1, 1, 1],
                0.05m);

            yield return new BrokerCase(
                "ThreeDifferentCapitals",
                [1, 2, 3],
                0.09m);

            yield return new BrokerCase(
                "AlreadySorted",
                [1, 2, 3, 4],
                0.19m);

            yield return new BrokerCase(
                "ReverseOrder",
                [4, 3, 2, 1],
                0.19m);

            yield return new BrokerCase(
                "UnorderedCapitals",
                [30, 10, 40, 20],
                1.90m);

            // Сначала объединяем две единицы:
            // 2 + 102 = 104.
            yield return new BrokerCase(
                "OneLargeCapital",
                [1, 100, 1],
                1.04m);

            // Два слияния по 2_000_000,
            // затем одно на 4_000_000.
            yield return new BrokerCase(
                "FourMaximumCapitals",
                [1_000_000, 1_000_000, 1_000_000, 1_000_000],
                80_000m);

            yield return new BrokerCase(
                "MaximumCount_MinimumCapitals",
                Enumerable.Repeat(1, 1_000_000).ToArray(),
                199_514.24m);

            yield return new BrokerCase(
                "MaximumCount_MaximumCapitals",
                Enumerable.Repeat(1_000_000, 1_000_000).ToArray(),
                199_514_240_000m);
        }
    }

    public sealed class BrokerCase(
        string name,
        int[] capitals,
        decimal expected)
    {
        public int[] Capitals { get; } = capitals;
        public decimal Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}