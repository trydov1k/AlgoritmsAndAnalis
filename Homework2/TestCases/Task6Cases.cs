namespace HomeWork2.TestCases;

public static class Task6Cases
{
    public sealed class NovelCase(
        string name,
        int[] chapters,
        int k,
        int expected)
    {
        public int[] Chapters { get; } = chapters;
        public int K { get; } = k;
        public int Expected { get; } = expected;

        public override string ToString() => name;
    }

    public static IEnumerable<NovelCase> Cases
    {
        get
        {
            yield return new(
                "Standard1",
                [1, 2, 1],
                2,
                3);

            yield return new(
                "Standard2",
                [1, 2, 1, 1],
                3,
                2);

            yield return new(
                "SingleChapter",
                [1],
                1,
                1);

            yield return new(
                "SingleChapter_MaximumPages",
                [32767],
                1,
                32767);

            // Все главы должны попасть в один том.
            yield return new(
                "SingleVolume",
                [10, 20, 30, 40],
                1,
                100);

            // Каждая глава становится отдельным томом.
            yield return new(
                "OneVolumePerChapter",
                [10, 20, 30, 40],
                4,
                40);

            yield return new(
                "EqualChapters",
                [5, 5, 5, 5, 5],
                2,
                15);

            // Оптимально: [7, 2, 5] и [10, 8].
            yield return new(
                "UnequalChapters",
                [7, 2, 5, 10, 8],
                2,
                18);

            // Ограничение порядка важно:
            // нельзя объединить две главы по 6 в один том.
            yield return new(
                "ChapterOrderMatters",
                [6, 1, 6],
                2,
                7);

            yield return new(
                "LargeChapterInMiddle",
                [1, 1, 100, 1, 1],
                3,
                100);

            // Максимальное N, минимальные положительные размеры глав.
            // В одном из трёх томов будет 34 главы.
            yield return new(
                "MaxN_EqualChapters",
                Enumerable.Repeat(1, 100).ToArray(),
                3,
                34);

            // Максимальное N и максимальное K.
            yield return new(
                "MaxN_MaxK",
                Enumerable.Repeat(1, 100).ToArray(),
                100,
                1);

            // 99 * 327 + 394 = 32767.
            yield return new(
                "MaxN_MaximumTotalPages_SingleVolume",
                Enumerable.Repeat(327, 99)
                    .Append(394)
                    .ToArray(),
                1,
                32767);

            // Два тома: 50 * 327 и 49 * 327 + 394.
            yield return new(
                "MaxN_MaximumTotalPages_TwoVolumes",
                Enumerable.Repeat(327, 99)
                    .Append(394)
                    .ToArray(),
                2,
                16417);
        }
    }
}