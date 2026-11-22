namespace HomeWork2.TestCases;

public static class Task29Cases
{
    public sealed class SubstringCase(
        string name,
        string text,
        int expected)
    {
        public string Text { get; } = text;
        public int Expected { get; } = expected;

        public override string ToString() => name;
    }

    public static IEnumerable<SubstringCase> Cases
    {
        get
        {
            yield return new(
                "Standard",
                "aaba",
                8);

            yield return new(
                "SingleCharacter",
                "a",
                1);

            yield return new(
                "TwoEqualCharacters",
                "aa",
                2);

            yield return new(
                "TwoDifferentCharacters",
                "ab",
                3);

            yield return new(
                "AllCharactersEqual",
                "aaaaa",
                5);

            yield return new(
                "AllCharactersDifferent",
                "abcde",
                15);

            // a, b, ab, ba, aba.
            yield return new(
                "OverlappingOccurrences",
                "aba",
                5);

            yield return new(
                "AlternatingCharacters",
                "ababa",
                9);

            yield return new(
                "RepeatedBlock",
                "abcabc",
                15);

            yield return new(
                "Banana",
                "banana",
                15);

            // Все буквы различны: 26 * 27 / 2.
            yield return new(
                "WholeAlphabet",
                "abcdefghijklmnopqrstuvwxyz",
                351);

            yield return new(
                "MaxLength_AllEqual",
                new string('a', 5000),
                5000);

            // Для чередующейся строки длины N ответ равен 2N - 1.
            yield return new(
                "MaxLength_Alternating",
                string.Concat(Enumerable.Repeat("ab", 2500)),
                9999);

            // 4999 подстрок только из a
            // и 5000 различных подстрок, заканчивающихся на b.
            yield return new(
                "MaxLength_DifferentLastCharacter",
                new string('a', 4999) + "b",
                9999);

            // Для каждой длины число вариантов равно
            // min(26, 5000 - length + 1).
            yield return new(
                "MaxLength_RepeatedAlphabet",
                new string(
                    Enumerable.Range(0, 5000)
                        .Select(i => (char)('a' + i % 26))
                        .ToArray()),
                129675);
        }
    }
}