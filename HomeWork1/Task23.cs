using Algorithms.Algorithms.Sorters;

namespace HomeWork1;

public class Task23
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var participants = new Task12.Participant[n];

        for (var i = 0; i < n; i++)
        {
            var parts = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            participants[i] = new Task12.Participant(
                parts[0],
                int.Parse(parts[1]),
                int.Parse(parts[2]));
        }

        foreach (var participant in Solve(participants))
            Console.WriteLine(participant.Login);
    }

    public static Task12.Participant[] Solve(Task12.Participant[] participants)
    {
        Sorters.HeapSort(participants);
        return participants;
    }
}