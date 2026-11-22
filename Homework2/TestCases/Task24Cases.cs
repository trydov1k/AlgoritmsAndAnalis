namespace HomeWork2.TestCases;

public static class Task24Cases
{
    public sealed class SpellCase(
        string name,
        string spell,
        int expectedPower)
    {
        public string Spell { get; } = spell;
        public int ExpectedPower { get; } = expectedPower;

        public override string ToString() => name;
    }

    public static IEnumerable<SpellCase> Cases
    {
        get
        {
            yield return new(
                "Standard",
                "tebidohtebidoh",
                2);

            yield return new(
                "SingleLetter",
                "a",
                1);

            yield return new(
                "SingleLetterZ",
                "z",
                1);

            yield return new(
                "AllLettersEqual",
                "aaaaa",
                5);

            yield return new(
                "AllLettersDifferent",
                "abcdef",
                1);

            yield return new(
                "OverlappingOccurrences",
                "abababa",
                4);

            yield return new(
                "EqualMaximumFrequencies",
                "aabbcc",
                2);

            yield return new(
                "MostFrequentLetterAtEnd",
                "abczzzz",
                4);

            yield return new(
                "NonConsecutiveOccurrences",
                "abacada",
                4);

            yield return new(
                "WholeAlphabet",
                "abcdefghijklmnopqrstuvwxyz",
                1);

            // Максимальная длина строки.
            yield return new(
                "MaxLength_AllEqual",
                new string('a', 50),
                50);

            yield return new(
                "MaxLength_Alternating",
                string.Concat(Enumerable.Repeat("ab", 25)),
                25);

            yield return new(
                "MaxLength_LastLetterWins",
                new string('a', 24) + new string('z', 26),
                26);

            yield return new(
                "MaxLength_AlphabetRepeated",
                "abcdefghijklmnopqrstuvwxyz" +
                "abcdefghijklmnopqrstuvwx",
                2);
        }
    }
}