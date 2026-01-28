using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var sb = new StringBuilder();
        char prev = '\0';

        foreach (char c in input.Trim())
        {
            if (c != prev)
                sb.Append(c);
            prev = c;
        }

        var parts = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
        }

        Console.WriteLine(string.Join(" ", parts));
    }
}
