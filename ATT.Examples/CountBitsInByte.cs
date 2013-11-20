using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class CountBitsInByte
    {
        public static void Main(string[] args)
        {
            byte input = 215;
            Console.WriteLine("Using BitArray class: " + CountOnBitsInByteUsingBitArray(input).ToString());
            Console.WriteLine("Using Shifting: " + CountOnBitsInByteUsingShifting(input).ToString());
            Console.ReadLine();
        }

        private static int CountOnBitsInByteUsingShifting(byte input)
        {
            int count = 0;

            for (int index = 0; index < 8; index++)
            {
                bool isBitOn = ((input >> index) & 1) != 0;
                if (isBitOn)
                    count++;
            }

            return count;
        }

        private static int CountOnBitsInByteUsingBitArray(byte input)
        {
            BitArray bits = new BitArray(new byte[] { input });
            int count = 0;

            foreach (bool bit in bits)
            {
                if (bit)
                    count++;
            }

            return count;
        }
    }
}
