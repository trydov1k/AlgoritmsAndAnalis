namespace HomeWork1.TestCases;

public sealed class TeamCase(
    string name,
    int n,
    int k,
    List<(int, int)> friends,
    int expectedCohesion)
{
    public int N { get; } = n;
    public int K { get; } = k;
    public List<(int, int)> Friends { get; } = friends;

    // Максимальная сумма сплочённостей обеих команд
    public int ExpectedCohesion { get; } = expectedCohesion;

    public override string ToString()
    {
        return name;
    }
}

public class Task10Cases
{
    public static IEnumerable<TeamCase> Cases
    {
        get
        {
            yield return new TeamCase(
                "Standard",
                5, 3,
                new List<(int, int)> { (1, 3), (2, 5), (5, 4) },
                3);

            yield return new TeamCase(
                "TwoPlayers_NoFriends",
                2, 1,
                new List<(int, int)>(),
                0);

            // Участники обязательно окажутся в разных командах.
            yield return new TeamCase(
                "TwoPlayers_Friends",
                2, 1,
                new List<(int, int)> { (1, 2) },
                0);

            yield return new TeamCase(
                "NoFriends",
                6, 3,
                new List<(int, int)>(),
                0);

            // Можно оставить обе пары внутри команд.
            yield return new TeamCase(
                "NonConsecutiveTeams",
                4, 2,
                new List<(int, int)> { (1, 3), (2, 4) },
                2);

            // Оптимально разделить на {1, 2} и {3, 4}.
            yield return new TeamCase(
                "Chain",
                4, 2,
                new List<(int, int)> { (1, 2), (2, 3), (3, 4) },
                2);

            // Каждая тройка образует полностью знакомую команду.
            yield return new TeamCase(
                "TwoTriangles",
                6, 3,
                new List<(int, int)>
                {
                    (1, 2), (1, 3), (2, 3),
                    (4, 5), (4, 6), (5, 6)
                },
                6);

            // В одиночную команду выгодно отправить любого "листа".
            yield return new TeamCase(
                "Star_FirstTeamOnePlayer",
                6, 1,
                new List<(int, int)> { (1, 2), (1, 3), (1, 4), (1, 5), (1, 6) },
                4);

            yield return new TeamCase(
                "Star_SecondTeamOnePlayer",
                6, 5,
                new List<(int, int)> { (1, 2), (1, 3), (1, 4), (1, 5), (1, 6) },
                4);

            // Две последовательные тройки сохраняют 4 знакомства.
            yield return new TeamCase(
                "Cycle",
                6, 3,
                new List<(int, int)>
                {
                    (1, 2), (2, 3), (3, 4),
                    (4, 5), (5, 6), (6, 1)
                },
                4);

            // Знакомую тройку можно оставить во второй команде,
            // выбрав в первую двух незнакомых участников.
            yield return new TeamCase(
                "IsolatedPlayers",
                5, 2,
                new List<(int, int)> { (1, 2), (1, 3), (2, 3) },
                3);

            // Проверка максимального номера участника.
            yield return new TeamCase(
                "MaxPlayers_NoFriends",
                24, 12,
                new List<(int, int)>(),
                0);
        }
    }
}