namespace HomeWork1.TestCases;

public class Task25Cases
{
    public sealed class HeapCase(
        string name,
        int[] values,
        bool expected)
    {
        public int[] Values { get; } = values;
        public bool Expected { get; } = expected;

        public override string ToString() => name;
    }

    public static IEnumerable<HeapCase> Cases
    {
        get
        {
            yield return new(
                "SingleElement",
                [42],
                true);

            yield return new(
                "TwoElements_Valid",
                [1, 2],
                true);

            yield return new(
                "TwoElements_Invalid",
                [2, 1],
                false);

            // Равенство родителя и детей допустимо.
            yield return new(
                "AllElementsEqual",
                [5, 5, 5, 5, 5, 5],
                true);

            yield return new(
                "SortedArray",
                [1, 2, 3, 4, 5, 6, 7],
                true);

            // Пирамида не обязана быть отсортированным массивом.
            yield return new(
                "UnsortedArray_ValidHeap",
                [1, 3, 2, 7, 4, 6, 5],
                true);

            yield return new(
                "LeftChildViolation",
                [5, 3, 7],
                false);

            yield return new(
                "RightChildViolation",
                [5, 7, 3],
                false);

            // Корень удовлетворяет условию,
            // но родитель 4 больше своего правого ребёнка 3.
            yield return new(
                "InternalNodeViolation",
                [1, 4, 2, 5, 3, 6, 7],
                false);

            // У последнего родителя есть только левый ребёнок.
            yield return new(
                "LastParentWithOnlyLeftChild_Valid",
                [1, 3, 2, 7, 4, 6],
                true);

            yield return new(
                "LastParentWithOnlyLeftChild_Invalid",
                [1, 3, 2, 7, 4, 0],
                false);

            yield return new(
                "NegativeValues",
                [-10, -5, -8, -1, -3, -7, -6],
                true);

            yield return new(
                "BoundaryValues",
                [-2_000_000_000, 0, 2_000_000_000],
                true);
        }
    }
}