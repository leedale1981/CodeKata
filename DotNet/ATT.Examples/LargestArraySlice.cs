using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ATT.Examples
{
    class LargestArraySlice
    {
        static IEnumerable<int> ParseIntegerSequence(string input, String delimiter)
        {
            // You shouldn't need to change this code
            // but you are certainly free to if you wish
            input = Regex.Replace(input ?? "", "[^\\-0-9,]", "");
            var inputItems = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in inputItems)
            {
                int parsedItem = 0;

                if (int.TryParse(item, out parsedItem))
                    yield return parsedItem;
            }
        }

        static void Main(string[] args)
        {
            var userInput = Console.ReadLine();
            var inputSequence = ParseIntegerSequence(userInput, ",");
            int largestSliceSize = CalculateLargestSlice(inputSequence);
            Console.WriteLine(largestSliceSize);
        }

        static int CalculateLargestSlice(IEnumerable<int> inputSequence)
        {
            // Your code goes here, use Console.WriteLine() for debugging
            // but comment out your debug statements once you're done

            // Use the "Run Code" button below to try out your code as you go

            List<int> sliceResults = new List<int>();
            List<int> inputSequenceList = new List<int>(inputSequence);

            for (int startIndex = 0; startIndex < inputSequenceList.Count; startIndex++)
            {
                sliceResults.Add(GetSliceResult(startIndex, inputSequenceList));
            }

            sliceResults.Sort();
            int highestResult = sliceResults.LastOrDefault();

            return highestResult;
        }

        /// <summary>
        /// Returns the slice size for the specified input and start index.
        /// </summary>
        /// <param name="startIndex">Index for the slice to start at.</param>
        /// <param name="inputSequence">Input sequence.</param>
        /// <returns>Integer containing size of the slice.</returns>
        private static int GetSliceResult(int startIndex, List<int> inputSequence)
        {
            List<int> sliceList = new List<int>();
            int numberCount = 1;

            for (int index = startIndex; index < inputSequence.Count; index++)
            {
                int current = inputSequence[index];

                if (index > startIndex)
                {
                    int previous = inputSequence[index - 1];

                    if (sliceList.Contains(current))
                    {
                        sliceList.Add(current);
                    }
                    else
                    {
                        if (previous != current)
                        {
                            numberCount++;
                        }

                        if (numberCount > 2)
                        {
                            break;
                        }
                        else
                        {
                            sliceList.Add(current);
                        }
                    }
                }
                else
                {
                    sliceList.Add(current);
                }
            }

            return sliceList.Count();
        }
    }
}
