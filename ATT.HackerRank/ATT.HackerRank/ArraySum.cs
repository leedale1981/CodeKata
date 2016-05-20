using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.HackerRank
{
    class ArraySum
    {
        static void Main(String[] args)
        {
            long n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            long[] arr = Array.ConvertAll(arr_temp, Int64.Parse);

            Console.WriteLine(Sum(arr));
        }

        static long Sum(long[] array)
        {
            return array.Sum();
        }
    }
}
