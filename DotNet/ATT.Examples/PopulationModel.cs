using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class PopulationModel
    {
        public static void Main(string[] args)
        {
            double currentPredatorPopulation = 2;
            double predatorIncrease = 1.2;
            double currentCompetitionEffect = -0.002;
            double lastYearCompetitionEffect = -0.002;
            Dictionary<int, double> populationDynamics = new Dictionary<int, double>();
            populationDynamics.Add(0, currentPredatorPopulation);

            for (int year = 1; year <= 50; year++)
            {
                currentPredatorPopulation = GetPredatorPopulationNextYear(
                    currentPredatorPopulation,
                    populationDynamics[year -1],
                    predatorIncrease,
                    currentCompetitionEffect,
                    lastYearCompetitionEffect);

                populationDynamics.Add(year, currentPredatorPopulation);
            }

            foreach(int year in populationDynamics.Keys)
            {
                Console.WriteLine("Year: " + year + ", Predator Population: " + populationDynamics[year]);
            }

            Console.ReadLine();
        }

        private static double GetPredatorPopulationNextYear(
            double currentPredators,
            double lastYearPredators,
            double predatorIncrease,
            double currentCompetitionEffect,
            double lastYearCopetitionEffect)
        {
            double e = 2.7183;
            double expo = 
            (
                currentCompetitionEffect * currentPredators 
                + lastYearCopetitionEffect * lastYearPredators
            );

            double constant = Math.Pow(e, expo);
            return predatorIncrease * currentPredators * constant;
        }
    }
}
