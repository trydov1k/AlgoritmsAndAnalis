namespace HomeWork2.TestCases;

public static class Task9Cases
{
    public static IEnumerable<PhoneBookCase> Cases
    {
        get
        {
            yield return new PhoneBookCase(
                "Standard",
                [
                    "ADD IVAN 1178927",
                    "PRINT PETER",
                    "ADD EGOR 123412",
                    "PRINT IVAN",
                    "EDITPHONE IVAN 112358",
                    "PRINT IVAN",
                    "PRINT EGOR",
                    "DELETE EGOR",
                    "EDITHPHONE EGOR 123456"
                ],
                [
                    "ERROR",
                    "IVAN 1178927",
                    "IVAN 112358",
                    "EGOR 123412",
                    "ERROR"
                ]);

            yield return new PhoneBookCase(
                "SingleCommand_Add",
                ["ADD IVAN 123"],
                []);

            yield return new PhoneBookCase(
                "PrintMissingUser",
                ["PRINT IVAN"],
                ["ERROR"]);

            // Повторное добавление не меняет старый номер.
            yield return new PhoneBookCase(
                "DuplicateUser",
                [
                    "ADD IVAN 123",
                    "ADD IVAN 456",
                    "PRINT IVAN"
                ],
                ["ERROR", "IVAN 123"]);

            yield return new PhoneBookCase(
                "DeleteExistingUser",
                [
                    "ADD IVAN 123",
                    "DELETE IVAN",
                    "PRINT IVAN"
                ],
                ["ERROR"]);

            yield return new PhoneBookCase(
                "DeleteMissingUser",
                ["DELETE IVAN"],
                ["ERROR"]);

            yield return new PhoneBookCase(
                "EditExistingUser",
                [
                    "ADD IVAN 123",
                    "EDITPHONE IVAN 456",
                    "PRINT IVAN"
                ],
                ["IVAN 456"]);

            yield return new PhoneBookCase(
                "EditMissingUser",
                ["EDITPHONE IVAN 456"],
                ["ERROR"]);

            yield return new PhoneBookCase(
                "AddAfterDeletion",
                [
                    "ADD IVAN 123",
                    "DELETE IVAN",
                    "ADD IVAN 456",
                    "PRINT IVAN"
                ],
                ["IVAN 456"]);

            yield return new PhoneBookCase(
                "PhoneNumberFormatting",
                [
                    "ADD IVAN 00123",
                    "PRINT IVAN",
                    "EDITPHONE IVAN +79991234567",
                    "PRINT IVAN"
                ],
                ["IVAN 00123", "IVAN +79991234567"]);

            yield return new PhoneBookCase(
                "DifferentUsers_SameNumber",
                [
                    "ADD IVAN 123",
                    "ADD EGOR 123",
                    "PRINT IVAN",
                    "PRINT EGOR"
                ],
                ["IVAN 123", "EGOR 123"]);

            // Максимальное количество записей в книге.
            yield return new PhoneBookCase(
                "MaxCommands_AllAdds",
                Enumerable.Range(1, 1000)
                    .Select(i => $"ADD USER{i} {i}")
                    .ToArray(),
                []);

            // Максимальное количество строк результата.
            yield return new PhoneBookCase(
                "MaxCommands_AllErrors",
                Enumerable.Range(1, 1000)
                    .Select(i => $"PRINT USER{i}")
                    .ToArray(),
                Enumerable.Repeat("ERROR", 1000).ToArray());

            // 500 добавлений + 500 запросов = 1000 команд.
            yield return new PhoneBookCase(
                "MaxCommands_AddAndPrint",
                Enumerable.Range(1, 500)
                    .Select(i => $"ADD USER{i} {i}")
                    .Concat(
                        Enumerable.Range(1, 500)
                            .Select(i => $"PRINT USER{i}"))
                    .ToArray(),
                Enumerable.Range(1, 500)
                    .Select(i => $"USER{i} {i}")
                    .ToArray());
        }
    }

    public sealed class PhoneBookCase(
        string name,
        string[] commands,
        string[] expected)
    {
        public string[] Commands { get; } = commands;
        public string[] Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}