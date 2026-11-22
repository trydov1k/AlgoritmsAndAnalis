using Homework2.Tasks;

namespace HomeWork2.TestCases;

public static class Task16Cases
{
    public static IEnumerable<TaxiCase> Cases
    {
        get
        {
            yield return new TaxiCase(
                "SingleClient",
                [new Task16.Point(0, 0)],
                3,
                []);

            yield return new TaxiCase(
                "TwoClients_WithinRadius",
                [new Task16.Point(0, 0), new Task16.Point(1, 0)],
                2,
                [new Task16.Station(0, 1), new Task16.Station(1, 1)]);

            yield return new TaxiCase(
                "TwoClients_OnBoundary",
                [new Task16.Point(0, 0), new Task16.Point(3, 4)],
                5,
                [new Task16.Station(0, 1), new Task16.Station(1, 1)]);

            yield return new TaxiCase(
                "TwoClients_OutsideRadius",
                [new Task16.Point(0, 0), new Task16.Point(3, 4)],
                4,
                []);

            yield return new TaxiCase(
                "ThreeClients_Chain",
                [new Task16.Point(0, 0), new Task16.Point(2, 0), new Task16.Point(4, 0)],
                2,
                [new Task16.Station(1, 2), new Task16.Station(0, 1), new Task16.Station(2, 1)]);

            yield return new TaxiCase(
                "AllClientsWithinRadius",
                [new Task16.Point(0, 0), new Task16.Point(1, 0), new Task16.Point(0, 1), new Task16.Point(1, 1)],
                2,
                [
                    new Task16.Station(0, 3), new Task16.Station(1, 3), new Task16.Station(2, 3),
                    new Task16.Station(3, 3)
                ]);

            yield return new TaxiCase(
                "NegativeCoordinates",
                [new Task16.Point(-3, -4), new Task16.Point(0, 0), new Task16.Point(3, 4)],
                5,
                [new Task16.Station(1, 2), new Task16.Station(0, 1), new Task16.Station(2, 1)]);

            yield return new TaxiCase(
                "FractionalCoordinates",
                [new Task16.Point(0, 0), new Task16.Point(0.5, 0), new Task16.Point(1, 0)],
                0.5,
                [new Task16.Station(1, 2), new Task16.Station(0, 1), new Task16.Station(2, 1)]);

            // Изолированная точка не попадает в результат.
            yield return new TaxiCase(
                "IsolatedClient",
                [new Task16.Point(0, 0), new Task16.Point(1, 0), new Task16.Point(100, 100)],
                2,
                [new Task16.Station(0, 1), new Task16.Station(1, 1)]);

            // Из 11 одинаково выгодных станций выбираем первые 10.
            yield return new TaxiCase(
                "MoreThanTenStations",
                Enumerable.Range(0, 11)
                    .Select(i => new Task16.Point(i, 0))
                    .ToArray(),
                10,
                Enumerable.Range(0, 10)
                    .Select(i => new Task16.Station(i, 10))
                    .ToArray());

            yield return new TaxiCase(
                "Standard2",
                [
                    new Task16.Point(3.168070, 1.752490),
                    new Task16.Point(0.500730, 6.436580),
                    new Task16.Point(0.089300, 0.112720),
                    new Task16.Point(2.275440, 7.508780),
                    new Task16.Point(0.779230, 4.377090),
                    new Task16.Point(0.644400, 1.381650),
                    new Task16.Point(1.844920, 1.430420),
                    new Task16.Point(8.079870, 5.225030),
                    new Task16.Point(7.823270, 5.317290),
                    new Task16.Point(1.788400, 5.426120)
                ],
                3,
                [
                    new Task16.Station(5, 4),
                    new Task16.Station(1, 3),
                    new Task16.Station(4, 3),
                    new Task16.Station(6, 3),
                    new Task16.Station(9, 3),
                    new Task16.Station(0, 2),
                    new Task16.Station(2, 2),
                    new Task16.Station(3, 2),
                    new Task16.Station(7, 1),
                    new Task16.Station(8, 1)
                ]);

            // Нагрузочный тест. Все станции обслуживают 999 клиентов.
            yield return new TaxiCase(
                "LargeInput_1000Clients",
                Enumerable.Range(0, 1000)
                    .Select(i => new Task16.Point(i, 0))
                    .ToArray(),
                1000,
                Enumerable.Range(0, 10)
                    .Select(i => new Task16.Station(i, 999))
                    .ToArray());

            yield return new TaxiCase(
                "LargeInput_1000IsolatedClients",
                Enumerable.Range(0, 1000)
                    .Select(i => new Task16.Point(i * 10, 0))
                    .ToArray(),
                1,
                []);
        }
    }

    public sealed class TaxiCase(
        string name,
        Task16.Point[] clients,
        double radius,
        Task16.Station[] expected)
    {
        public Task16.Point[] Clients { get; } = clients;
        public double Radius { get; } = radius;
        public Task16.Station[] Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}