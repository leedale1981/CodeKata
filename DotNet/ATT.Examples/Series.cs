using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ATT.Examples
{
    public class Series
    {
        static void Main(string[] args)
        {
            int a = 1;
            int n = 10000;

            var watch = Stopwatch.StartNew();
            watch.Start();
            int sum = SumNaturalNumbers_Loop(a, n);
            watch.Stop();
            Console.WriteLine("Sum of series " + a + " to " + n + " looping took " + watch.Elapsed);
            Console.WriteLine("Sum is " + sum);

            watch.Reset();
            watch.Start();
            sum = SumNaturalNumbers_Formula(a, n);
            watch.Stop();
            Console.WriteLine("Sum of series " + a + " to " + n + "  by using a formula took " + watch.Elapsed);
            Console.WriteLine("Sum is " + sum);
        }

        public static int SumNaturalNumbers_Loop(int a, int n)
        {
            int sum = a;

            for (int i = a + 1; i <= n; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static int SumNaturalNumbers_Formula(int a, int n)
        {
            return (int)((0.5) * (double)n * ((double)n + 1));
        }
    }
}
