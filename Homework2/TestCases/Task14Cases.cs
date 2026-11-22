namespace HomeWork2.TestCases;

public static class Task14Cases
{
    public static IEnumerable<PatternCase> Cases
    {
        get
        {
            yield return new PatternCase(
                "Standard1",
                "ABRACADABRA",
                "ABRA*ABRA",
                true);

            yield return new PatternCase(
                "Standard2",
                "FOOBAR",
                "F??B??",
                true);

            yield return new PatternCase(
                "Standard3",
                "FOOBAR",
                "F*??O*",
                false);

            yield return new PatternCase(
                "SingleCharacter_Match",
                "A",
                "A",
                true);

            yield return new PatternCase(
                "SingleCharacter_Mismatch",
                "A",
                "B",
                false);

            yield return new PatternCase(
                "QuestionMark_OneCharacter",
                "A",
                "?",
                true);

            yield return new PatternCase(
                "QuestionMark_CannotMatchTwoCharacters",
                "AB",
                "?",
                false);

            yield return new PatternCase(
                "Star_MatchesEmpty",
                "AB",
                "A*B",
                true);

            yield return new PatternCase(
                "Star_MatchesSeveralCharacters",
                "ABCDE",
                "A*E",
                true);

            yield return new PatternCase(
                "ConsecutiveStars",
                "ABCDE",
                "**A***?**E**",
                true);

            yield return new PatternCase(
                "ExactMatch",
                "ABCDEF",
                "ABCDEF",
                true);

            // Совпадения только части имени недостаточно.
            yield return new PatternCase(
                "WholeNameMustMatch",
                "ABCD",
                "ABC",
                false);

            // Части по обе стороны звёздочки не могут перекрываться.
            yield return new PatternCase(
                "OverlappingParts_NotAllowed",
                "AAA",
                "AA*AA",
                false);

            // Проверяем обработку пустых префиксов.
            yield return new PatternCase(
                "EmptyName_Stars",
                "",
                "***",
                true);

            yield return new PatternCase(
                "EmptyName_QuestionMark",
                "",
                "?",
                false);

            yield return new PatternCase(
                "MaxLength_ExactMatch",
                new string('A', 700),
                new string('A', 700),
                true);

            yield return new PatternCase(
                "MaxLength_AllQuestionMarks",
                new string('A', 700),
                new string('?', 700),
                true);

            yield return new PatternCase(
                "MaxLength_AllStars",
                new string('A', 700),
                new string('*', 700),
                true);

            yield return new PatternCase(
                "MaxLength_LastCharacterMismatch",
                new string('A', 700),
                new string('A', 699) + "B",
                false);

            // 350 пар "*?" — образец длиной 700.
            yield return new PatternCase(
                "MaxLength_StarsAndQuestionMarks",
                new string('A', 700),
                string.Concat(Enumerable.Repeat("*?", 350)),
                true);

            // Звёздочки не могут компенсировать отсутствие буквы B.
            yield return new PatternCase(
                "MaxLength_StarsAndMissingLetter",
                new string('A', 700),
                new string('*', 699) + "B",
                false);
        }
    }

    public sealed class PatternCase(
        string name,
        string fileName,
        string pattern,
        bool expected)
    {
        public string FileName { get; } = fileName;
        public string Pattern { get; } = pattern;
        public bool Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}