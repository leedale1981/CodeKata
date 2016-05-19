using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class Program
    {
        static int passes = 1;

        static void Main(string[] args)
        {
            int[] input = new int[] { 5, 1, 4, 2, 8, 21, 13, 75, 9, 45, 32, 78, 98, 12, 17, 22 };
            Console.WriteLine("Input array is " + string.Join(",", input.Select(p => p.ToString()).ToArray()));
            Console.WriteLine("Sorting...");
            Console.WriteLine("Output array is " + string.Join(",", BubbleSort(input).Select(p => p.ToString()).ToArray()));
            Console.WriteLine("Number of passes: " + passes);
        }

        public static int[] BubbleSort(int[] input)
        {
            bool swoped = false;

            for (int index = 0; index < input.Length - 1; index++)
            {
                int first = input[index];
                int second = input[index + 1];

                if (first > second)
                {
                    input[index] = second;
                    input[index + 1] = first;
                    swoped = true;
                }
            }

            if (swoped)
            {
                passes++;
                return BubbleSort(input);
            }
            else
            {
                return input;
            }
        }
    }
}
