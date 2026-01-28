using System;

class Program
{
    static int SumDigits(long x)
    {
        int sum = 0;
        while (x > 0)
        {
            sum += (int)(x % 10);
            x /= 10;
        }
        return sum;
    }

    static bool IsPrime(int x)
    {
        if (x <= 1) return false;
        if (x <= 3) return true;
        if (x % 2 == 0 || x % 3 == 0) return false;
        for (int i = 5; i * i <= x; i += 6)
        {
            if (x % i == 0 || x % (i + 2) == 0) return false;
        }
        return true;
    }

    static void Main()
    {
        var input = Console.ReadLine().Split();
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        int count = 0;

        for (int x = m; x <= n; x++)
        {
            if (x > 0 && !IsPrime(x))
            {
                int s = SumDigits(x);
                int ss = SumDigits((long)x * x);
                if (ss == s * s)
                    count++;
            }
        }

        Console.WriteLine(count);
    }
}
