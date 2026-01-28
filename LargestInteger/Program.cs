using System;

class Program
{
    static int LargestOfThree(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }

    static void Main()
    {
        var input = Console.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);
        Console.WriteLine(LargestOfThree(a, b, c));
    }
}
