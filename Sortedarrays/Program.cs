using System;
using System.Linq;

class Program
{
    static T[] MergeSorted<T>(T[] a, T[] b) where T : IComparable<T>
    {
        int i = 0, j = 0, k = 0;
        T[] res = new T[a.Length + b.Length];

        while (i < a.Length && j < b.Length)
        {
            if (a[i].CompareTo(b[j]) <= 0)
                res[k++] = a[i++];
            else
                res[k++] = b[j++];
        }

        while (i < a.Length) res[k++] = a[i++];
        while (j < b.Length) res[k++] = b[j++];

        return res;
    }

    static void Main()
    {
        var a = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var merged = MergeSorted(a, b);

        Console.WriteLine(string.Join(" ", merged));
    }
}
