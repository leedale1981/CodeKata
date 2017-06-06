using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    /// <summary>
    /// Equilibrium index of an array is an index such that the sum of elements at 
    /// lower indexes is equal to the sum of elements at higher indexes
    /// http://www.geeksforgeeks.org/equilibrium-index-of-an-array/
    /// </summary>
    class EquilibirumArray
    {
        public static void Main(string[] args)
        {
            int[] array = { -7, 1, 5, 2, -4, 3, 0 };
            BalanceArray(array).ForEach(e => Console.Write(e.ToString() + ", "));
            Console.ReadLine();
        }

        /// <summary>
        /// Solution is O(n^2)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<int> BalanceArray(int[] array)
        {
            List<int> equilibirum = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int leftsum = 0;
                int rightsum = 0;

                for (int j = 0; j < i; j++)
                    leftsum += array[j];

                for (int j = i+1; j < array.Length; j++)
                    rightsum += array[j];

                if (leftsum == rightsum)
                    equilibirum.Add(i);
            }

            return equilibirum;
        }
    }
}
