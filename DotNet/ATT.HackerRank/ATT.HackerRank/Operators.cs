using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.HackerRank
{
    class Operators
    {
        static void Main(String[] args)
        {
            double mealCost = Convert.ToDouble(Console.ReadLine());
            int tipPercent = Convert.ToInt32(Console.ReadLine());
            int taxPercent = Convert.ToInt32(Console.ReadLine());

            int totalCost = CalculateMealCost(mealCost, tipPercent, taxPercent);
            Console.WriteLine("The total meal cost is " + totalCost + " dollars.");
        }

        private static int CalculateMealCost(double mealCost, int tipPercent, int taxPercent)
        {
            double tip = mealCost * tipPercent / 100;
            double tax = mealCost * taxPercent / 100;

            return  Convert.ToInt32(Math.Round(mealCost + tip + tax));
        }
    }
}
