using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class ReverseArray
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5 };

            ListReverse(input);
            ArrayReverse(input);
            ForReverse(input);

        }

        private static void ForReverse(int[] input)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            int[] output = new int[input.Length];
            int count = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output[i] = input[count];
                count++;
            }

            timer.Stop();

            Console.WriteLine("Input: " + string.Join(",", input));
            Console.WriteLine("Output: " + string.Join(",", output));
            Console.WriteLine("For loop reverse took " + timer.Elapsed);
            Console.WriteLine("");
        }

        private static void ArrayReverse(int[] input)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            int[] output = input.Reverse().ToArray();
            timer.Stop();

            Console.WriteLine("Input: " + string.Join(",", input));
            Console.WriteLine("Output: " + string.Join(",", output));
            Console.WriteLine("Array IEnumerable reverse took " + timer.Elapsed);
            Console.WriteLine("");
        }

        private static void ListReverse(int[] input)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            List<int> list = new List<int>(input);
            list.Reverse();
            int[] output = list.ToArray();
            timer.Stop();

            Console.WriteLine("Input: " + string.Join(",", input));
            Console.WriteLine("Output: " + string.Join(",", output));
            Console.WriteLine("List reverse took " + timer.Elapsed);
            Console.WriteLine("");
        }
    }
}
