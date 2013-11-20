using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    public class Indexer
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc[0] = 1;
            Console.WriteLine(mc[0].ToString());
        }
    }

    public class MyClass
    {
        private int[] data = new int[10];

        public int this[int index]
        {
            get { return data[index]; }
            set { data[index] = value;}
        }
    }
}
