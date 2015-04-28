using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    public class Search
    {
        public static void Main(string[] args)
        {
            int[] values = { 1, 4, 7, 2, 3, 18, 28, 13, 22, 8, 33, 81, 30 };
            Console.Write("Original values {");
            for (int index = 0; index < values.Length; index++)
            {
                Console.Write(values[index]);
                if (index < values.Length - 1) { Console.Write(", "); }
            }
            Console.Write("}");
            Console.WriteLine("");

            int[] sortedValues = Sorting.InsertionSort(values);
            Console.Write("Sorted values {");
            for (int index = 0; index < sortedValues.Length; index++)
            {
                Console.Write(sortedValues[index]);
                if (index < sortedValues.Length - 1) { Console.Write(", "); }
            }
            Console.Write("}");
            Console.WriteLine("");

            int valueToFind = 4;
            Console.WriteLine("Value to find: " + valueToFind);
            
            int indexOfValue = BinarySearch(valueToFind, sortedValues, 0, sortedValues.Length);
            Console.WriteLine("Index of value: " + indexOfValue);
        }

        /// <summary>
        /// Returns the index of a specified value using a binary search algorithm.
        /// </summary>
        /// <param name="value">Value to search for.</param>
        /// <param name="values">Sorted array of values.</param>
        /// <param name="min">Start index of values array to search within.</param>
        /// <param name="max">End index of values array to search within.</param>
        /// <returns>Integer value specifying the index of the value we are searching for.</returns>
        internal static int BinarySearch(int value, int[] values, int min, int max)
        {
            //  Find the middle index
            int middle = ((max - min) / 2) + min;
 
            //  Test to see if we have found the value we are looking for
            if (value == values[middle])
            {
                return middle;
            }
            else
            {
                //  If we don't find the value test to see if value is less than or greater than 
                //  the middle value in the array.
                if (value < values[middle])
                {
                    //  Recursively call this method with min and max indexes set to a range
                    //  that includes the lower half of the current array range.
                    return BinarySearch(value, values, min, middle);
                }
                else
                {
                    //  Recursively call this method with min and max indexes set to a range
                    //  that includes the upper half of the current array range.
                    return BinarySearch(value, values, middle, values.Length);
                }
            }
        }
    }
}
