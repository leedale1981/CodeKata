using System;
using System.Collections.Generic;
using System.IO;

namespace ATT.HackerRank
{
    class DictionariesAndMaps
    {
       static void Main(String[] args)
       {
            int entries = int.Parse(Console.ReadLine());
            var entriesList = GetEntriesList(entries);
            var lookups = GetLookups();
            OutputLookups(lookups, entriesList);
       }

        private static void OutputLookups(List<string> lookups, Dictionary<string, string> entriesList)
        {
            foreach (string lookup in lookups)
            {
                if (entriesList.ContainsKey(lookup))
                {
                    string number = entriesList[lookup];
                    Console.WriteLine(lookup + "=" + number);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }

        private static List<string> GetLookups()
        {
            string lookupName = Console.ReadLine();
            var lookups = new List<string>();

            while (Console.KeyAvailable)
            {
                lookups.Add(lookupName);
                lookupName = Console.ReadLine();
            }

            return lookups;
        }

        private static Dictionary<string, string> GetEntriesList(int entries)
        {
            var entriesList = new Dictionary<string, string>();

            for (int index = 0; index < entries; index++)
            {
                string entry = Console.ReadLine();
                string name = entry.Split(' ')[0];
                string number = entry.Split(' ')[1];

                entriesList.Add(name, number);
            }

            return entriesList;
        }
    }
}
