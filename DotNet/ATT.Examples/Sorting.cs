using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ATT.Examples
{
    public class Sorting
    {
        public static void Main(string[] args)
        {
            int[] input = { 5, 2, 4, 6, 1, 3, 12, 10, 13, 8, 9, 11 };
            Console.Write("Sorting input: ");
            foreach (int item in input)
                Console.Write(item + ", ");
            Console.Write("\r\n");
            Console.WriteLine("-------");
            Console.Write("\r\n");

            Stopwatch insertionSortStopWatch = Stopwatch.StartNew();
            int[] insertionSortOutput = InsertionSort(input);
            insertionSortStopWatch.Stop();

            Console.Write("Insertion sort output: ");
            foreach (int item in insertionSortOutput)
                Console.Write(item + ", ");
            Console.Write("\r\n");
            Console.WriteLine("Insertion sort took: " + insertionSortStopWatch.Elapsed);

            int[] unsorted = UnSort(insertionSortOutput);
            Console.Write("Un-sort output: ");
            foreach (int item in unsorted)
                Console.Write(item + ", ");
        }

        internal static int[] InsertionSort(int[] input)
        {
            for (int index = 1; index < input.Length; index++)
            {
                int current = input[index];
                int j = index - 1;
                
                while ((j >= 0) && (input[j] > current))
                {
                    input[j + 1] = input[j];
                    j--;
                }

                input[j + 1] = current;
            }

            return input;
        }

        private static int[] UnSort(int[] input)
        {
            for (int index = 0; index < input.Length; index++)
            {
                int randomIndex = -1;
                while (randomIndex < 0 || randomIndex > input.Length)
                {
                    randomIndex = new Random(input.Length).Next();
                }

                int current = input[index];
                input[index] = input[randomIndex];
                input[randomIndex] = current;
            }

            return input;
        }
    }
}
