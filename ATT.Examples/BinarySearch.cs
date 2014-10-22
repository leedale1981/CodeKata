using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class BinarySearch
    {
        public static void Main(string[] args)
        {
            int[] values = { 1, 4, 7, 2, 3, 18, 28, 13, 22, 8, 33, 81, 30 };
            int[] sortedValues = Sorting.InsertionSort(values);
            int valueToFind = 4;

            int index = Search(valueToFind, sortedValues, 0, sortedValues.Length);
        }

        private static int Search(int value, int[] values, int min, int max)
        {
            int middle = ((max - min) / 2) + min;
 
            if (value == values[middle])
            {
                return middle;
            }
            else
            {
                if (value < values[middle])
                {
                    return Search(value, values, min, middle);
                }
                else
                {
                    return Search(value, values, middle, values.Length);
                }
            }
        }
    }
}
