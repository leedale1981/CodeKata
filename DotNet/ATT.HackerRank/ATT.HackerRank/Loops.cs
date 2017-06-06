using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Loops
{
    static void Main(String[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        for (int count = 1; count <= 10; count++)
        {
            int result = N * count;
            Console.WriteLine(N + " x " + count + " = " + result);
        }
    }
}