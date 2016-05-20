using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int numberChildren = 17;// int.Parse(Console.ReadLine());
        int[] ratings = { 35108, 62711, 60129, 60129, 60129, 85771, 2583, 29356, 71665, 71665, 71665, 10267, 28009, 28009, 76451, 57315, 57315 };// new int[numberChildren]; 

        //for (int index = 0; index < numberChildren; index++)
        //{
        //    ratings[index] = int.Parse(Console.ReadLine());
        //}

        int[] candies = GiveOutCandiesUp(new int[numberChildren], ratings);
        candies = GiveOutCandiesDown(candies, ratings);
        Console.WriteLine(candies.Sum());
    }

    private static int[] GiveOutCandiesUp(int[] candies, int[] ratings)
    {
        for (int index = 0; index < ratings.Length; index++)
        {
            if (index == 0)
            {
                candies[index] = 1;
                continue;
            }

            int myCandies = candies[index];
            int myRating = ratings[index];
            int beforeCandies = candies[index - 1];
            int beforeRating = ratings[index - 1];
            
            if (myRating > beforeRating)
            {
                candies[index] = beforeCandies + 1;
            }

            if (myRating == beforeRating)
            {
                candies[index] = beforeCandies - 1;
            }

            if (candies[index] == 0) candies[index] = 1;
        }

        return candies;
    }

    private static int[] GiveOutCandiesDown(int[] candies, int[] ratings)
    {
        for (int index = ratings.Length -1; index > 0; index--)
        {
            if (index == ratings.Length - 1) continue;

            int myCandies = candies[index];
            int myRating = ratings[index];
            int beforeCandies = candies[index + 1];
            int beforeRating = ratings[index + 1];

            if (myRating > beforeRating)
            {
                candies[index] = beforeCandies + 1;
            }

            if (myRating < beforeRating)
            {
                candies[index + 1] = myCandies + 1;
            }

            if (candies[index] == 0) candies[index] = 1;
        }

        return candies;
    }
}