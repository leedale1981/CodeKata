using System;
using System.Collections.Generic;
using System.IO;
class LetsReview
{
    static void Main(String[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        string[] i =  new string[N];

        for (int index = 0; index < N; index++)
        {
            i[index] = Console.ReadLine();
        }

        PrintStrings(i, N);
    }

    private static void PrintStrings(string[] i, int N)
    {
        for (int sindex = 0; sindex < N; sindex++)
        {
            string even = string.Empty;
            string odd = string.Empty;
            char[] chars = i[sindex].ToCharArray();

            for (int cindex = 0; cindex < chars.Length; cindex++)
            {
                if (cindex % 2 == 0)
                {
                    even += chars[cindex];
                }
                else
                {
                    odd += chars[cindex];
                }
            }

            Console.WriteLine(even + " " + odd);
        }
    }
}