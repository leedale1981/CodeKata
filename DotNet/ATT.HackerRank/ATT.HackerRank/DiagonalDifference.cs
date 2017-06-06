using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.HackerRank
{
    class DiagonalDifference
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] a = new int[n][];
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }

            int answer = Calculate(a, n);
            Console.WriteLine(answer);
        }

        static int Calculate(int[][] matrix, int n)
        {
            int a_sum = 0;
            int b_sum = 0;

            for (int a_i = 0; a_i < n; a_i++)
            {
                int b_i = (n - 1) - a_i;
                a_sum += matrix[a_i][a_i];
                b_sum += matrix[a_i][b_i];
            }

            return Math.Abs(a_sum - b_sum);
        }
    }
}
