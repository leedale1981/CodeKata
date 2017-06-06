using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    public class Delegates
    {
        private delegate string MyDelegate(string myString);

        static void Main(string[] args)
        {
            Func<bool> func1 = () => true;
            Console.WriteLine(func1());

            Func<string, string> func2 = a => a + " Test!";
            Console.WriteLine(func2("Hello World"));

            Action<int> func3 = a => a += 1;
            func3(5);

            MyDelegate myDelegate = delegate(string myString) 
            {
                myString += " Test!";
                return myString;
            };
            Console.WriteLine(myDelegate("Hello World Again"));

            Func<int, string> func4 = delegate(int myInt)
            {
                myInt++;
                myInt %= 3;
                return myInt.ToString();
            };
            Console.WriteLine(func4(45));

            Console.WriteLine(Calculate(1981, func4));
        }

        private static int Calculate(int myNumber, Func<int, string> methodToCalculate)
        {
            return int.Parse(methodToCalculate(myNumber));
        }
    }
}
