using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var data = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long balance = data[0];

        for (int i = 1; i < data.Length; i++)
        {
            long t = data[i];
            if (t >= 0)
                balance += t;
            else if (balance + t >= 0)
                balance += t;
        }

        Console.WriteLine(balance);
    }
}
