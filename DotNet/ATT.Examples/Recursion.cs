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

            BigInteger number = 15; // BigInteger.Parse(args[0]);
            BigInteger answer = GetFactorial(number);

            stopWatch.Stop();

            Console.WriteLine("Factorial of " + number + " is " + answer);
            Console.WriteLine("Time taken: " + stopWatch.Elapsed.ToString());

            stopWatch.Reset();
            stopWatch.Start();
            List<BigInteger> answers = GetFactors(number);

            stopWatch.Stop();
        }

        private static BigInteger GetFactorial(BigInteger number)
        {
            if (number <= 1)
                return 1;
            else
                return number * GetFactorial(number - 1);
        }

        private static List<BigInteger> GetFactors(BigInteger number)
        {
            BigInteger max = number / 2;
            List<BigInteger> factors = new List<BigInteger>();

            for (int index = 1; index <= max; index++)
            {
                if (number % index == 0)
                {
                    factors.Add(index);
                }
            }

            return factors;
        }
    }
}
