using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ATT.Examples
{
    public class HashtableVsDictionary
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();
            hash.Add("Key", "Hash Value");
            Console.WriteLine(hash["Key"].ToString());

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Key", 10);
            Console.WriteLine(dictionary["Key"]);
        }
    }
}
