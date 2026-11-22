namespace HomeWork2.TestCases;

public static class Task19Cases
{
    public static IEnumerable<PumpingCase> Cases
    {
        get
        {
            yield return new PumpingCase(
                "Standard1",
                "abcd",
                "abcbcbcd",
                1);

            yield return new PumpingCase(
                "Standard2",
                "aaa",
                "aaaaa",
                5);

            yield return new PumpingCase(
                "Standard3",
                "abbababacaab",
                "abbababababacaab",
                8);

            yield return new PumpingCase(
                "MinimumLengths_Match",
                "a",
                "aa",
                1);

            yield return new PumpingCase(
                "MinimumLengths_Mismatch",
                "a",
                "ab",
                0);

            yield return new PumpingCase(
                "RepeatWholeString",
                "abcd",
                "abcdabcd",
                1);

            yield return new PumpingCase(
                "RepeatAtBeginning",
                "ab",
                "aab",
                1);

            yield return new PumpingCase(
                "RepeatAtEnd",
                "ab",
                "abb",
                1);

            yield return new PumpingCase(
                "RepeatTwoCharacters",
                "abc",
                "ababc",
                1);

            // Можно выбрать любую из трёх букв a в качестве y.
            yield return new PumpingCase(
                "SeveralPossiblePositions",
                "aaa",
                "aaaa",
                3);

            // Совпадающие начало и конец не гарантируют
            // правильность повторяемой середины.
            yield return new PumpingCase(
                "MatchingEnds_InvalidMiddle",
                "abc",
                "abxc",
                0);

            // Максимальные длины: n = 9 999 999, m = 10 000 000.
            // difference = 1, поэтому длина y может быть только 1.
            yield return new PumpingCase(
                "MaxLengths_AllEqual",
                new string('a', 9_999_999),
                new string('a', 10_000_000),
                9_999_999);

            // Длины максимальны, а ответ отрицательный.
            yield return new PumpingCase(
                "MaxLengths_InvalidMiddle",
                new string('a', 9_999_999),
                new string('a', 5_000_000) +
                "b" +
                new string('a', 4_999_999),
                0);

            // Максимальная длина t, минимальная длина s.
            yield return new PumpingCase(
                "MinS_MaxT",
                "a",
                new string('a', 10_000_000),
                1);

            yield return new PumpingCase(
                "ManyDivisors_AllEqual",
                new string('a', 5_010_400),
                new string('a', 10_000_000),
                1_781_058_312L);
        }
    }

    public sealed class PumpingCase(
        string name,
        string s,
        string t,
        long expected)
    {
        public string S { get; } = s;
        public string T { get; } = t;
        public long Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}