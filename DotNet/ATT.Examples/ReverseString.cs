using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class ReverseString
    {
        public static void Main(string[] args)
        {
            string input = "reverse me";
            Stopwatch timer = new Stopwatch();

            timer.Start();
            string outputLinq = UsingLinq(input);
            timer.Stop();
            Console.WriteLine("Using LINQ: " + outputLinq + " - time taken: " + timer.Elapsed.ToString());
            timer.Reset();

            timer.Start();
            string outputArrayOnly = UsingArrayOnly(input);
            timer.Stop();
            Console.WriteLine("Using array only: " + outputArrayOnly + " - time taken: " + timer.Elapsed.ToString());
            timer.Reset();

            Console.ReadLine();
        }

        private static string UsingLinq(string input)
        {
            char[] output = input.Reverse().ToArray();
            return string.Join(string.Empty, output);
        }

        private static string UsingArrayOnly(string input)
        {
            char[] inputArray = input.ToCharArray();
            string output = string.Empty;

            for (int index = inputArray.Length -1; index >= 0 ; index--)
            {
                output += inputArray[index];
            }

            return output;
        }
    }
}
