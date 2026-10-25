using Algorithms.Algorithms.Sorters;

namespace HomeWork1;

public static class Task14
{
    public static void Sort()
    {
        var n = int.Parse(Console.ReadLine());  // n <= 1000
        var k =  int.Parse(Console.ReadLine());  // 1 <= k <= 10
        var priorities  = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        var entries = new Entry[n];

        for (var i = 0; i < n; i++)
        {
            var parts = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            entries[i] = new Entry(
                parts[0],
                parts.Skip(1).Select(int.Parse).ToArray(),
                priorities);
        }

        foreach (var entry in Sort(entries))
        {
            Console.WriteLine(entry.Name);
        }
    }

    public static Entry[] Sort(Entry[] entries)
    {
        Sorters.QuickSortInPlace(entries);
        return entries;
    }
    
    
    public sealed class Entry(string name, int[] parameters, int[] priorities) 
        : IComparable
    {
        public string Name { get; } = name;
        public int[] Parameters { get; } = parameters;

        public int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;

            if (obj is not Entry second)
                throw new ArgumentException(
                    "Ожидался объект типа Entry.", nameof(obj));

            var first = this;
            
            foreach (var priority  in priorities)
            {
                var index = priority - 1;
                
                // По убыванию: большее значение идёт раньше.
                var comparison =
                    second.Parameters[index].CompareTo(first.Parameters[index]);

                if (comparison != 0)
                    return comparison;
            }

            return 0;
        }
    }
}