using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class CoinTossProbability
    {
        static void Main(String[] args)
        {
            int n = 12; // Coin tosses
            double[] probabilities = CalculateProbabilities(n);

            for (int toss = 0; toss < n; toss++)
            {
                Console.WriteLine("Toss " + (toss + 1) + " probability = " + probabilities[toss]);
            }
        }

        static double[] CalculateProbabilities(int n)
        {
            double p = (3 / 2); // Coin bias
            double[] probs = new double[n];

            for (int toss = 0; toss < n; toss++)
            {
                double probHeadsOccurs = ProbabilityThatHeadsOccurs(p, n, toss);
                probs[toss] = probHeadsOccurs;
            }

            return probs;
        }

        static double ProbabilityThatHeadsOccurs(double p, int n, int k)
        {
            double q = 1 - p; // Probability that tails occurs;
            return p * p *(n - 1) * (k - 1) + q * p * (n - 1) * k;
        }
    }
}
