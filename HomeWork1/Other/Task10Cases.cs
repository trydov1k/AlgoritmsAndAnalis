namespace HomeWork1.Other;

public sealed class TeamCase(string name, int n, int k,
    List<(int, int)> friends, int expectedCohesion)
{
    public int N { get; } = n;
    public int K { get; } = k;
    public List<(int, int)> Friends { get; } = friends;

    // Максимальная сумма сплочённостей обеих команд
    public int ExpectedCohesion { get; } = expectedCohesion;

    public override string ToString() => name;
}

public class Task10Cases
{
    public static IEnumerable<TeamCase> Cases
    {
        get
        {
            yield return new(
                "Standard",
                5, 3,
                new() { (1, 3), (2, 5), (5, 4)},
                3);
            
            yield return new(
                "TwoPlayers_NoFriends",
                2, 1,
                new(),
                0);
            
            // Участники обязательно окажутся в разных командах.
            yield return new(
                "TwoPlayers_Friends",
                2, 1,
                new() { (1, 2) },
                0);
            
            yield return new(
                "NoFriends",
                6, 3,
                new(),
                0);
            
            // Можно оставить обе пары внутри команд.
            yield return new(
                "NonConsecutiveTeams",
                4, 2,
                new() { (1, 3), (2, 4) },
                2);
            
            // Оптимально разделить на {1, 2} и {3, 4}.
            yield return new(
                "Chain",
                4, 2,
                new() { (1, 2), (2, 3), (3, 4) },
                2);
            
            // Каждая тройка образует полностью знакомую команду.
            yield return new(
                "TwoTriangles",
                6, 3,
                new()
                {
                    (1, 2), (1, 3), (2, 3),
                    (4, 5), (4, 6), (5, 6)
                },
                6);
            
            // В одиночную команду выгодно отправить любого "листа".
            yield return new(
                "Star_FirstTeamOnePlayer",
                6, 1,
                new() { (1, 2), (1, 3), (1, 4), (1, 5), (1, 6) },
                4);

            yield return new(
                "Star_SecondTeamOnePlayer",
                6, 5,
                new() { (1, 2), (1, 3), (1, 4), (1, 5), (1, 6) },
                4);

            // Две последовательные тройки сохраняют 4 знакомства.
            yield return new(
                "Cycle",
                6, 3,
                new()
                {
                    (1, 2), (2, 3), (3, 4),
                    (4, 5), (5, 6), (6, 1)
                },
                4);

            // Знакомую тройку можно оставить во второй команде,
            // выбрав в первую двух незнакомых участников.
            yield return new(
                "IsolatedPlayers",
                5, 2,
                new() { (1, 2), (1, 3), (2, 3) },
                3);

            // Проверка максимального номера участника.
            yield return new(
                "MaxPlayers_NoFriends",
                24, 12,
                new(),
                0);
        }
    }
}