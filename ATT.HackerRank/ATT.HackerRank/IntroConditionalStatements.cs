using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class ConditionalStatements
{
    static void Main(String[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        switch (N % 2)
        {
            case 0:
                if (N >= 2 && N <= 5)
                {
                    Console.WriteLine("Not Weird");
                }

                if (N >= 6 && N <= 20)
                {
                    Console.WriteLine("Weird");
                }

                if (N > 20)
                {
                    Console.WriteLine("Not Weird");
                }

                break;

            default:
                Console.WriteLine("Weird");
                break;

        }
    }
}
