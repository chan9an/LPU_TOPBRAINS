using System;

class Program
{
    static string GetCategory(int heightCm)
    {
        if (heightCm < 150) return "Short";
        if (heightCm < 180) return "Average";
        return "Tall";
    }

    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine(GetCategory(height));
    }
}
