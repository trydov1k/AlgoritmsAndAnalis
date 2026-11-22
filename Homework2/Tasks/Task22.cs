namespace Homework2.Tasks;

public static class Task22
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);

        IEnumerable<string> ReadStrings()
        {
            for (var i = 0; i < n; i++)
                yield return Console.ReadLine()!;
        }

        Console.WriteLine(Solve(ReadStrings()));
    }

    public static string Solve(IEnumerable<string> packedStrings)
    {
        const int maxLength = 100_000;

        var prefix = new char[maxLength];
        var buffer = new char[maxLength];

        var stack = new Algorithms.Structures.Stack<(int Start, int Repeats)>();

        var prefixLength = 0;
        var first = true;

        foreach (var packed in packedStrings)
        {
            if (first)
            {
                prefixLength = Unpack(
                    packed, prefix, maxLength, stack);

                first = false;

                if (prefixLength == 0)
                    return string.Empty;

                continue;
            }

            prefixLength = Unpack(
                packed, buffer, prefixLength, stack, prefix);

            if (prefixLength == 0)
                return string.Empty;
        }

        return new string(prefix, 0, prefixLength);
    }

    private static int Unpack(
    string packed,
    char[] buffer,
    int limit,
    Algorithms.Structures.Stack<(int Start, int Repeats)> stack,
    char[]? expectedPrefix = null)
{
    var size = 0;
    var stackSize = 0;

    try
    {
        for (var i = 0; i < packed.Length && size < limit; i++)
        {
            var symbol = packed[i];

            if (symbol >= 'a' && symbol <= 'z')
            {
                if (expectedPrefix is not null &&
                    expectedPrefix[size] != symbol)
                    return size;

                buffer[size++] = symbol;
            }
            else if (symbol >= '1' && symbol <= '9')
            {
                stack.Push((size, symbol - '0'));
                stackSize++;
                i++; // Пропускаем '['.
            }
            else if (symbol == ']')
            {
                var (start, repeats) = stack.Pop();
                stackSize--;

                var blockLength = size - start;

                for (var repeat = 1;
                     repeat < repeats && size < limit;
                     repeat++)
                {
                    var copyLength = Math.Min(blockLength, limit - size);

                    if (expectedPrefix is null)
                    {
                        Array.Copy(buffer, start, buffer, size, copyLength);
                        size += copyLength;
                        continue;
                    }

                    for (var j = 0; j < copyLength; j++)
                    {
                        var nextSymbol = buffer[start + j];

                        if (expectedPrefix[size] != nextSymbol)
                            return size;

                        buffer[size++] = nextSymbol;
                    }
                }
            }
        }

        return size;
    }
    finally
    {
        // При досрочном выходе убираем незакрытые блоки.
        while (stackSize > 0)
        {
            stack.Pop();
            stackSize--;
        }
    }
}
}