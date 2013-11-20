using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ATT.Examples
{
    public class Recursion
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            BigInteger number = BigInteger.Parse(args[0]);
            BigInteger answer = GetFactorial(number);

            stopWatch.Stop();

            Console.WriteLine("Factorial of " + number + " is " + answer);
            Console.WriteLine("Time taken: " + stopWatch.Elapsed.ToString());
        }

        private static BigInteger GetFactorial(BigInteger number)
        {
            if (number <= 1)
                return 1;
            else
                return number * GetFactorial(number - 1);
        }
    }
}
