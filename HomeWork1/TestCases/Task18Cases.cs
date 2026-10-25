namespace HomeWork1.TestCases;

public class Task18Cases
{
    public sealed class VisitCase(
        string name,
        (int Arrival, int Departure)[] visits,
        int expected)
    {
        public (int Arrival, int Departure)[] Visits { get; } = visits;
        public int Expected { get; } = expected;

        public override string ToString() => name;
    }

    public static IEnumerable<VisitCase> Cases
    {
        get
        {
            yield return new(
                "Standard",
                [
                    (540, 607),   // 09:00–10:07
                    (620, 695),   // 10:20–11:35
                    (720, 1020),  // 12:00–17:00
                    (660, 690),   // 11:00–11:30
                    (680, 750),   // 11:20–12:30
                    (690, 1095)   // 11:30–18:15
                ],
                4);

            yield return new(
                "SingleVisitor",
                [
                    (540, 600)
                ],
                1);

            // Между посещениями есть перерывы.
            yield return new(
                "NoOverlaps",
                [
                    (540, 600),
                    (601, 660),
                    (661, 720)
                ],
                1);

            yield return new(
                "IdenticalVisits",
                [
                    (540, 600),
                    (540, 600),
                    (540, 600),
                    (540, 600)
                ],
                4);

            // Вложенные интервалы: все пересекаются в 10:30.
            yield return new(
                "NestedVisits",
                [
                    (540, 900),
                    (570, 840),
                    (600, 780),
                    (630, 720)
                ],
                4);

            // В минуту ухода первого приходит второй.
            yield return new(
                "ArrivalAtDepartureTime",
                [
                    (540, 600),
                    (600, 660)
                ],
                2);

            // Все трое присутствуют в минуту 600.
            yield return new(
                "ZeroDurationVisits",
                [
                    (600, 600),
                    (600, 600),
                    (600, 600)
                ],
                3);

            // Границы суток: 00:00 и 23:59.
            yield return new(
                "DayBoundaries",
                [
                    (0, 1439),
                    (0, 0),
                    (1439, 1439)
                ],
                2);

            // Порядок входных записей не влияет на результат.
            yield return new(
                "UnorderedVisits",
                [
                    (720, 780),
                    (570, 630),
                    (540, 600),
                    (590, 620)
                ],
                3);

            // Утром максимум 2, вечером максимум 3.
            yield return new(
                "MultiplePeaks",
                [
                    (540, 600),
                    (570, 630),
                    (1080, 1200),
                    (1110, 1170),
                    (1140, 1230)
                ],
                3);
        }
    }
}