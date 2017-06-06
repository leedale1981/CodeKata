using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace ATT.Examples
{
    public class FizzBuzz
    {
        public static void Main(string[] args)
        {
            for (int number = 1; number <= 100; number++)
            {
                string output = number.ToString();

                if (number % 3 == 0)
                {
                    output = "Fizz";
                } 

                if (number % 5 == 0)
                {
                    output = "Buzz";
                }

                if (number % 3 == 0 &&
                    number % 5 == 0)
                {
                    output = "Fizz Buzz";
                }

                Console.WriteLine(output);
            }
        }
    }
}
