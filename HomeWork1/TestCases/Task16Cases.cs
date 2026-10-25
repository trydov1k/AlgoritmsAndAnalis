namespace HomeWork1.TestCases;

public class Task16Cases
{
    public static IEnumerable<SequenceCase> Cases
    {
        get
        {
            // После сортировки: 7, 27, 79, 83, 91.
            // (7 + 79 + 91) % 100 = 77.
            yield return new SequenceCase(
                "Standard",
                5, 7, 13, 100,
                77);

            yield return new SequenceCase(
                "SingleElement",
                1, 7, 13, 100,
                7);

            // Первый элемент равен K и не уменьшается по модулю L
            // при генерации. Модуль применяется к итоговой сумме.
            yield return new SequenceCase(
                "SingleElement_GreaterThanModulo",
                1, 123, 13, 100,
                23);

            // Последовательность состоит из нулей.
            yield return new SequenceCase(
                "ZeroInitialValue",
                5, 0, 13, 100,
                0);

            // Последовательность: 7, 0, 0, 0, 0.
            // После сортировки: 0, 0, 0, 0, 7.
            yield return new SequenceCase(
                "ZeroMultiplier",
                5, 7, 0, 100,
                7);

            // Все шесть элементов равны 7.
            // Берём три: 7 + 7 + 7 = 21.
            yield return new SequenceCase(
                "EqualElements_EvenLength",
                6, 7, 1, 100,
                21);

            // Любая итоговая сумма по модулю 1 равна 0.
            yield return new SequenceCase(
                "ModuloOne",
                5, 7, 13, 1,
                0);

            // Последовательность: 1, 2, 4, 1, 2, 4.
            // После сортировки: 1, 1, 2, 2, 4, 4.
            // (1 + 2 + 4) % 7 = 0.
            yield return new SequenceCase(
                "RepeatingCycle",
                6, 1, 2, 7,
                0);

            // Младшие 32 бита произведения uint.MaxValue² равны 1.
            // После сортировки: 1, uint.MaxValue.
            // Берём только первый элемент.
            yield return new SequenceCase(
                "MultiplicationOverflow",
                2, uint.MaxValue, uint.MaxValue, 100,
                1);

            // 2_147_483_648 * 2 после обрезания до 32 бит даёт 0.
            // После сортировки: 0, 0, 2_147_483_648.
            // Итог: 2_147_483_648 % 100 = 48.
            yield return new SequenceCase(
                "MultiplicationOverflow_ProducesZero",
                3, 2_147_483_648U, 2, 100,
                48);
        }
    }

    public static IEnumerable<SequenceCase> BenchmarkCases
    {
        get
        {
            foreach (var data in Cases)
                yield return data;

            // Большой вход для измерения производительности.
            // Ожидаемый результат бенчмарк не проверяет.
            yield return new SequenceCase(
                "LargeInput",
                5_000_000, 7, 13, 100,
                0);
        }
    }

    public sealed class SequenceCase(
        string name,
        int n,
        uint k,
        uint m,
        uint l,
        uint expected)
    {
        public int N { get; } = n;
        public uint K { get; } = k;
        public uint M { get; } = m;
        public uint L { get; } = l;
        public uint Expected { get; } = expected;

        public override string ToString()
        {
            return name;
        }
    }
}