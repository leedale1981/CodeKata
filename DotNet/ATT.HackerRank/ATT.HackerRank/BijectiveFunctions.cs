using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.HackerRank
{
    class BijectiveFunctions
    {
        static void Main(String[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] funcs = new int[input.Length];

            for (int index = 0; index < input.Length; index++)
            {
                funcs[index] = int.Parse(input[index]);
            }

            string answer = (IsBijective(funcs, n)) ? "YES" : "NO";
            Console.WriteLine(answer); 
        }

        private static bool IsBijective(int[] funcs, int n)
        {
            if (n == funcs.Length)
            {
                Array.Sort(funcs);

                for (int index = 0; index < n - 1; index++)
                {
                    if (funcs[index] < funcs[index + 1])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
