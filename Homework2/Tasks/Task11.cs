using Algorithms.Structures;

namespace Homework2.Tasks;

public static class Task11
{
    public static void Solve()
    {
        var input = Console.In.ReadToEnd()
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

        var capacity = int.Parse(input[0]);

        var requests = input
            .Skip(2)
            .Select(long.Parse)
            .ToArray();

        Console.WriteLine(Solve(capacity, requests));
    }

    public static int Solve(int capacity, long[] requests)
    {
        var nextUses = FindNextUses(requests);

        // Номер данных → актуальная позиция следующего обращения.
        var cache = new HashTableChaining<long, int>(16);

        var heap = new BinaryHeap(requests.Length);
        var misses = 0;

        for (var i = 0; i < requests.Length; i++)
        {
            var id = requests[i];

            if (!cache.ContainsKey(id))
            {
                misses++;

                if (cache.Size == capacity)
                    Evict(cache, heap, requests);
            }

            cache.Put(id, nextUses[i]);
            heap.Insert(-nextUses[i]);
        }

        return misses;
    }

    private static int[] FindNextUses(long[] requests)
    {
        var nextUses = new int[requests.Length];
        var positions = new HashTableChaining<long, int>(16);

        for (var i = requests.Length - 1; i >= 0; i--)
        {
            var id = requests[i];

            nextUses[i] = positions.ContainsKey(id)
                ? positions.Get(id)
                : requests.Length + i;

            positions.Put(id, i);
        }

        return nextUses;
    }

    private static void Evict(
        HashTableChaining<long, int> cache,
        BinaryHeap heap,
        long[] requests)
    {
        while (true)
        {
            var next = -heap.ExtractMin();

            // Для данных без следующего запроса записано M + i.
            var index = next < requests.Length
                ? next
                : next - requests.Length;

            var id = requests[index];

            // Пропускаем устаревшие записи кучи.
            if (!cache.ContainsKey(id) || cache.Get(id) != next)
                continue;

            cache.Remove(id);
            return;
        }
    }
}