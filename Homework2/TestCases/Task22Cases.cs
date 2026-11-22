namespace HomeWork2.TestCases;

public static class Task22Cases
{
    public static IEnumerable<PackedPrefixCase> Cases
    {
        get
        {
            yield return new PackedPrefixCase(
                "Standard1",
                [
                    "2[a]2[ab]",
                    "3[a]2[r2[t]]",
                    "a2[aa3[b]]"
                ],
                "aaa");

            yield return new PackedPrefixCase(
                "Standard2",
                [
                    "abacabaca",
                    "2[abac]a",
                    "3[aba]"
                ],
                "aba");

            yield return new PackedPrefixCase(
                "SingleLetter",
                ["a"],
                "a");

            yield return new PackedPrefixCase(
                "SinglePackedString",
                ["2[a3[b]]"],
                "abbbabbb");

            yield return new PackedPrefixCase(
                "NoCommonPrefix",
                ["abc", "bcd"],
                "");

            yield return new PackedPrefixCase(
                "IdenticalStrings",
                ["abc", "abc", "abc"],
                "abc");

            yield return new PackedPrefixCase(
                "DifferentPacking_SameText",
                ["ababab", "3[ab]", "ab2[ab]"],
                "ababab");

            yield return new PackedPrefixCase(
                "ShortestStringIsPrefix",
                ["abcdef", "abc", "abcd"],
                "abc");

            yield return new PackedPrefixCase(
                "PrefixEndsInsideRepeatedBlock",
                ["2[abc]", "abx"],
                "ab");

            yield return new PackedPrefixCase(
                "MultipleBlocks",
                ["2[ab]3[c]d", "ababccce"],
                "ababccc");

            yield return new PackedPrefixCase(
                "PrefixShrinksSeveralTimes",
                ["abcdef", "abcde", "abcd", "abc"],
                "abc");

            yield return new PackedPrefixCase(
                "MaximumRepeatDigit",
                ["9[a]", "aaaaaaaaab"],
                "aaaaaaaaa");

            // Глубокая вложенность без роста результата.
            yield return new PackedPrefixCase(
                "DeepNesting",
                [
                    string.Concat(Enumerable.Repeat("1[", 1000)) +
                    "a" +
                    new string(']', 1000),
                    "ab"
                ],
                "a");

            // Проверка нескольких уровней повторения.
            yield return new PackedPrefixCase(
                "NestedRepeats",
                ["9[9[9[9[a]]]]", "9[9[9[9[a]]]]"],
                new string('a', 6561));

            // 5 × 5 × 5 × 5 × 5 × 2 × 2 × 2 × 2 × 2 = 100 000.
            yield return new PackedPrefixCase(
                "Exactly100000Characters",
                [
                    "5[5[5[5[5[2[2[2[2[2[a]]]]]]]]]]",
                    new string('a', 100_000)
                ],
                new string('a', 100_000));

            // Максимальное количество строк.
            yield return new PackedPrefixCase(
                "MaxStringCount",
                Enumerable.Repeat("2[ab]", 1000).ToArray(),
                "abab");

            // Максимальное число строк и длина после распаковки.
            yield return new PackedPrefixCase(
                "MaxCount_MaxUnpackedLength",
                Enumerable.Repeat(
                    "5[5[5[5[5[2[2[2[2[2[a]]]]]]]]]]",
                    1000).ToArray(),
                new string('a', 100_000));

            // После первой строки префикс сокращается до одной буквы.
            yield return new PackedPrefixCase(
                "LongStrings_ShortPrefix",
                [
                    "5[5[5[5[5[2[2[2[2[2[a]]]]]]]]]]",
                    "ab",
                    "9[a]"
                ],
                "a");
        }
    }

    public sealed class PackedPrefixCase(
        string name,
        string[] packedStrings,
        string expected)
    {
        public string[] PackedStrings { get; } = packedStrings;
        public string Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}