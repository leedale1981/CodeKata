using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Arrays2
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        int[] reversed = ForReverse(arr);

        for (int index = 0; index < reversed.Length; index++)
        {
            Console.Write(reversed[index] + " ");
        }
    }

    private static int[] ForReverse(int[] input)
    { 
        int[] output = new int[input.Length];
        int count = 0;

        for (int i = input.Length - 1; i >= 0; i--)
        {
            output[i] = input[count];
            count++;
        }

        return output;
    }
}
