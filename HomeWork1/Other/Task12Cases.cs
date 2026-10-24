namespace HomeWork1.Other;

public static class Task12Cases
{
    public sealed class ParticipantCase(string name, Task12.Participant[] participants, string[] expectedLogins)
    {
        public string Name { get; } = name;
        public Task12.Participant[] Participants { get; } = participants;
        public string[] ExpectedLogins { get; } = expectedLogins;
        
        public override string ToString() => Name;
    }
    
    public static IEnumerable<ParticipantCase> Cases 
    {
        get
        {
            yield return new ParticipantCase(
                "Standard 1",
                [
                    new ("alla", 4, 100),
                    new("gena", 6, 1000),
                    new ("gosha", 2, 90),
                    new ("rita", 2, 90),
                    new("Timofey", 4, 80)
                ],
                ["gena", "timofey", "alla", "gosha", "rita"]
            );
            
            yield return new ParticipantCase(
                "Standard 2",
                [
                    new ("alla", 0, 0),
                    new("gena", 0, 0),
                    new ("gosha", 0, 0),
                    new ("rita", 0, 0),
                    new("Timofey", 0, 0)
                ],
                ["alla", "gena", "gosha", "rita", "timofey"]
            );
            
            yield return new ParticipantCase(
                "SingleParticipant",
                [
                    new("solo", 5, 100)
                ],
                ["solo"]
            );

            yield return new ParticipantCase(
                "AlreadySorted",
                [
                    new("anna", 10, 100),
                    new("boris", 8, 50),
                    new("victor", 8, 100),
                    new("dima", 3, 0)
                ],
                ["anna", "boris", "victor", "dima"]
            );

            yield return new ParticipantCase(
                "ReverseOrder",
                [
                    new("dima", 3, 0),
                    new("victor", 8, 100),
                    new("boris", 8, 50),
                    new("anna", 10, 100)
                ],
                ["anna", "boris", "victor", "dima"]
            );
            
            yield return new ParticipantCase(
                "SolvedCountHasPriority",  // Количество задач важнее штрафа.
                [
                    new("anna", 1, 0),
                    new("boris", 3, 1_000_000_000),
                    new("victor", 2, 500)
                ],
                ["boris", "victor", "anna"]
            );
            
            yield return new ParticipantCase(
                "PenaltyHasPriorityOverLogin",  // При одинаковом числе задач сравниваем штраф.
                [
                    new("anna", 5, 300),
                    new("zoya", 5, 0),
                    new("boris", 5, 100)
                ],
                ["zoya", "boris", "anna"]
            );
            
            yield return new ParticipantCase(
                "EqualScores_ShuffledLogins",  // При одинаковых показателях сравниваем логины.
                [
                    new("rita", 4, 80),
                    new("gosha", 4, 80),
                    new("alla", 4, 80),
                    new("gena", 4, 80)
                ],
                ["alla", "gena", "gosha", "rita"]
            );

            yield return new ParticipantCase(
                "LoginPrefixes",  // Более короткий логин идёт раньше, если он — префикс другого.
                [
                    new("aaa", 2, 10),
                    new("ab", 2, 10),
                    new("aa", 2, 10),
                    new("a", 2, 10)
                ],
                ["a", "aa", "aaa", "ab"]
            );
            
            yield return new ParticipantCase(
                "BoundaryValues",  // Граничные значения числа задач и штрафа.
                [
                    new("anna", 0, 1_000_000_000),
                    new("boris", 1_000_000_000, 1_000_000_000),
                    new("victor", 0, 0),
                    new("dima", 1_000_000_000, 0)
                ],
                ["dima", "boris", "victor", "anna"]
            );
        } 
    }
}