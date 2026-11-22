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

            var unpackedLength = Unpack(
                packed, buffer, prefixLength, stack);

            var commonLength = 0;
            var limit = Math.Min(prefixLength, unpackedLength);

            while (commonLength < limit &&
                   prefix[commonLength] == buffer[commonLength])
                commonLength++;

            prefixLength = commonLength;

            if (prefixLength == 0)
                return string.Empty;
        }

        return new string(prefix, 0, prefixLength);
    }

    private static int Unpack(
        string packed,
        char[] buffer,
        int limit, Algorithms.Structures.Stack<(int Start, int Repeats)> stack)
    {
        var size = 0;
        var stackSize = 0;

        for (var i = 0; i < packed.Length && size < limit; i++)
        {
            var symbol = packed[i];

            if (symbol >= 'a' && symbol <= 'z')
            {
                buffer[size++] = symbol;
            }
            else if (symbol >= '1' && symbol <= '9')
            {
                stack.Push((size, symbol - '0'));
                i++; // Пропускаем '['.
            }
            else if (symbol == ']')
            {
                var (start, repeats) = stack.Pop();
                var blockLength = size - start;

                for (var repeat = 1;
                     repeat < repeats && size < limit;
                     repeat++)
                {
                    var copyLength = Math.Min(
                        blockLength,
                        limit - size);

                    Array.Copy(
                        buffer, start,
                        buffer, size,
                        copyLength);

                    size += copyLength;
                }
            }
        }

        return size;
    }
}