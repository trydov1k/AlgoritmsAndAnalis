namespace HomeWork1.TestCases;

public class Task14Cases
{
    public static IEnumerable<EntryCase> Cases
    {
        get
        {
            yield return new EntryCase(
                "Standard", [
                    new Task14.Entry("A", [1, 2, 3], [2, 1, 3]),
                    new Task14.Entry("B", [3, 2, 1], [2, 1, 3]),
                    new Task14.Entry("C", [3, 1, 2], [2, 1, 3])
                ],
                ["B", "A", "C"]);

            // Одна запись.
            yield return new EntryCase(
                "SingleEntry", [
                    new Task14.Entry("Solo", [42], [1])
                ],
                ["Solo"]);

            // Одно поле: сортировка по убыванию.
            yield return new EntryCase(
                "SingleParameter_DescendingOrder", [
                    new Task14.Entry("A", [5], [1]),
                    new Task14.Entry("B", [10], [1]),
                    new Task14.Entry("C", [1], [1])
                ],
                ["B", "A", "C"]);

            // Уже отсортированные записи.
            yield return new EntryCase(
                "AlreadySorted", [
                    new Task14.Entry("A", [9, 3], [1, 2]),
                    new Task14.Entry("B", [7, 8], [1, 2]),
                    new Task14.Entry("C", [2, 1], [1, 2])
                ],
                ["A", "B", "C"]);

            // Записи расположены в обратном порядке.
            yield return new EntryCase(
                "ReverseOrder", [
                    new Task14.Entry("C", [2, 1], [1, 2]),
                    new Task14.Entry("B", [7, 8], [1, 2]),
                    new Task14.Entry("A", [9, 3], [1, 2])
                ],
                ["A", "B", "C"]);

            // Первое приоритетное поле важнее остальных.
            yield return new EntryCase(
                "FirstPriorityDecides", [
                    new Task14.Entry("A", [1, 100, 100], [1, 2, 3]),
                    new Task14.Entry("B", [3, 0, 0], [1, 2, 3]),
                    new Task14.Entry("C", [2, 50, 50], [1, 2, 3])
                ],
                ["B", "C", "A"]);

            // При равенстве первого поля сравнивается второе.
            yield return new EntryCase(
                "FirstPriorityEqual_SecondDecides", [
                    new Task14.Entry("A", [5, 10, 100], [1, 2, 3]),
                    new Task14.Entry("B", [5, 30, 0], [1, 2, 3]),
                    new Task14.Entry("C", [5, 20, 50], [1, 2, 3])
                ],
                ["B", "C", "A"]);

            // Первые два поля равны: результат определяет третье.
            yield return new EntryCase(
                "FirstTwoPrioritiesEqual_ThirdDecides", [
                    new Task14.Entry("A", [5, 5, 10], [1, 2, 3]),
                    new Task14.Entry("B", [5, 5, 30], [1, 2, 3]),
                    new Task14.Entry("C", [5, 5, 20], [1, 2, 3])
                ],
                ["B", "C", "A"]);

            // Обратный порядок приоритетов.
            // Сначала поле 3, затем поле 2, затем поле 1.
            yield return new EntryCase(
                "ReversedPriorities", [
                    new Task14.Entry("A", [100, 1, 5], [3, 2, 1]),
                    new Task14.Entry("B", [0, 2, 5], [3, 2, 1]),
                    new Task14.Entry("C", [0, 0, 6], [3, 2, 1]),
                    new Task14.Entry("D", [200, 1, 5], [3, 2, 1])
                ],
                ["C", "B", "D", "A"]);

            // Максимальное число полей: различается только десятое.
            // Проверяет преобразование номера поля 10 в индекс 9.
            yield return new EntryCase(
                "TenParameters_LastPriorityDecides", [
                    new Task14.Entry("A", [1, 1, 1, 1, 1, 1, 1, 1, 1, 2],
                        [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]),
                    new Task14.Entry("B", [1, 1, 1, 1, 1, 1, 1, 1, 1, 3],
                        [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]),
                    new Task14.Entry("C", [1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
                        [1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
                ],
                ["B", "A", "C"]);
        }
    }

    public sealed class EntryCase(string name, Task14.Entry[] entries, string[] Expected)
    {
        public string Name { get; } = name;
        public Task14.Entry[] Entries { get; } = entries;
        public string[] Expected { get; } = Expected;

        public override string ToString()
        {
            return Name;
        }
    }
}