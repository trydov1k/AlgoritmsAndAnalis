namespace Homework2.Tasks;

public static class Task9
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var commands = new string[n];

        for (var i = 0; i < n; i++)
            commands[i] = Console.ReadLine()!;

        foreach (var line in Solve(commands))
            Console.WriteLine(line);
    }

    public static string[] Solve(string[] commands)
    {
        var phoneBook = new Dictionary<string, string>();

        var result = new List<string>();

        foreach (var command in commands)
        {
            var parts = command.Split(
                ' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                result.Add("ERROR");
                continue;
            }

            var action = parts[0];
            var user = parts[1];

            switch (action)
            {
                case "ADD" when parts.Length == 3:
                    if (!phoneBook.TryAdd(user, parts[2]))
                        result.Add("ERROR");
                    break;

                case "DELETE" when parts.Length == 2:
                    if (!phoneBook.Remove(user))
                        result.Add("ERROR");
                    break;

                case "EDITPHONE" when parts.Length == 3:
                    if (phoneBook.ContainsKey(user))
                        phoneBook[user] = parts[2];
                    else
                        result.Add("ERROR");
                    break;

                case "PRINT" when parts.Length == 2:
                    if (phoneBook.TryGetValue(user, out var number))
                        result.Add($"{user} {number}");
                    else
                        result.Add("ERROR");
                    break;

                default:
                    result.Add("ERROR");
                    break;
            }
        }

        return result.ToArray();
    }
}