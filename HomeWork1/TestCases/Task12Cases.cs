namespace HomeWork1.TestCases;

public static class Task12Cases
{
    public static IEnumerable<ParticipantCase> Cases
    {
        get
        {
            yield return new ParticipantCase(
                "Standard 1",
                [
                    new Task12.Participant("alla", 4, 100),
                    new Task12.Participant("gena", 6, 1000),
                    new Task12.Participant("gosha", 2, 90),
                    new Task12.Participant("rita", 2, 90),
                    new Task12.Participant("Timofey", 4, 80)
                ],
                ["gena", "timofey", "alla", "gosha", "rita"]
            );

            yield return new ParticipantCase(
                "Standard 2",
                [
                    new Task12.Participant("alla", 0, 0),
                    new Task12.Participant("gena", 0, 0),
                    new Task12.Participant("gosha", 0, 0),
                    new Task12.Participant("rita", 0, 0),
                    new Task12.Participant("Timofey", 0, 0)
                ],
                ["alla", "gena", "gosha", "rita", "timofey"]
            );

            yield return new ParticipantCase(
                "SingleParticipant",
                [
                    new Task12.Participant("solo", 5, 100)
                ],
                ["solo"]
            );

            yield return new ParticipantCase(
                "AlreadySorted",
                [
                    new Task12.Participant("anna", 10, 100),
                    new Task12.Participant("boris", 8, 50),
                    new Task12.Participant("victor", 8, 100),
                    new Task12.Participant("dima", 3, 0)
                ],
                ["anna", "boris", "victor", "dima"]
            );

            yield return new ParticipantCase(
                "ReverseOrder",
                [
                    new Task12.Participant("dima", 3, 0),
                    new Task12.Participant("victor", 8, 100),
                    new Task12.Participant("boris", 8, 50),
                    new Task12.Participant("anna", 10, 100)
                ],
                ["anna", "boris", "victor", "dima"]
            );

            yield return new ParticipantCase(
                "SolvedCountHasPriority", // Количество задач важнее штрафа.
                [
                    new Task12.Participant("anna", 1, 0),
                    new Task12.Participant("boris", 3, 1_000_000_000),
                    new Task12.Participant("victor", 2, 500)
                ],
                ["boris", "victor", "anna"]
            );

            yield return new ParticipantCase(
                "PenaltyHasPriorityOverLogin", // При одинаковом числе задач сравниваем штраф.
                [
                    new Task12.Participant("anna", 5, 300),
                    new Task12.Participant("zoya", 5, 0),
                    new Task12.Participant("boris", 5, 100)
                ],
                ["zoya", "boris", "anna"]
            );

            yield return new ParticipantCase(
                "EqualScores_ShuffledLogins", // При одинаковых показателях сравниваем логины.
                [
                    new Task12.Participant("rita", 4, 80),
                    new Task12.Participant("gosha", 4, 80),
                    new Task12.Participant("alla", 4, 80),
                    new Task12.Participant("gena", 4, 80)
                ],
                ["alla", "gena", "gosha", "rita"]
            );

            yield return new ParticipantCase(
                "LoginPrefixes", // Более короткий логин идёт раньше, если он — префикс другого.
                [
                    new Task12.Participant("aaa", 2, 10),
                    new Task12.Participant("ab", 2, 10),
                    new Task12.Participant("aa", 2, 10),
                    new Task12.Participant("a", 2, 10)
                ],
                ["a", "aa", "aaa", "ab"]
            );

            yield return new ParticipantCase(
                "BoundaryValues", // Граничные значения числа задач и штрафа.
                [
                    new Task12.Participant("anna", 0, 1_000_000_000),
                    new Task12.Participant("boris", 1_000_000_000, 1_000_000_000),
                    new Task12.Participant("victor", 0, 0),
                    new Task12.Participant("dima", 1_000_000_000, 0)
                ],
                ["dima", "boris", "victor", "anna"]
            );
        }
    }

    public sealed class ParticipantCase(string name, Task12.Participant[] participants, string[] expectedLogins)
    {
        public string Name { get; } = name;
        public Task12.Participant[] Participants { get; } = participants;
        public string[] ExpectedLogins { get; } = expectedLogins;

        public override string ToString()
        {
            return Name;
        }
    }
}