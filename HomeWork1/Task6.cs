namespace HomeWork1;

public static class Task6
{
    /// <summary>
    /// Метод как необходим в задании
    /// </summary>
    public static void Solve()
    {
        var firstLine = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        var n = firstLine[0];
        var m = firstLine[1];
        var mod = firstLine[2];

        var coefficients = new List<int>();
        var values = new List<int>();

        for (var i = 0; i < n + 1; i++)
        {
            coefficients.Add(int.Parse(Console.ReadLine()));
        }
        for (var i = 0; i < m; i++)
        {
            values.Add(int.Parse(Console.ReadLine()));
        }
        
        foreach(var answer in Solve(coefficients, values, mod))
        {
            Console.WriteLine(answer);
        }
    }

    /// <summary>
    /// Метод, удобный для тестирования
    /// </summary>
    /// <param name="coefficients">коэффициенты ai</param>
    /// <param name="values">значения xi</param>
    /// <param name="mod">значение MOD</param>
    /// <returns>Возвращает ленивую коллекцию значений данного полинома при заданных значениях аргументов по модулю MOD</returns>
    public static IEnumerable<int> Solve(List<int> coefficients, List<int> values, int mod)
    {
        foreach (var x in values)
        {
            long result = coefficients[0];
            for (var i = 1; i < coefficients.Count; i++)
                result = (result * x + coefficients[i]) % mod;
            yield return (int)result;
        }
    }
}