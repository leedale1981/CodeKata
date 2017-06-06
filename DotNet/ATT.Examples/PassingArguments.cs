using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATT.Examples
{
    class PassingArguments
    {
        public static void Main(string[] args)
        {
            Test test = new Test();
            string myString = "My String ";
            MyObject myObject = new MyObject() { MyNumber = 29 };
            test.IntanceMethod(ref myString, myObject);
            Console.WriteLine(myString);
            Console.WriteLine(myObject.MyNumber);
        }
    }

    class Test
    {
        public void IntanceMethod(ref string myString, MyObject myObject)
        {
            //  The address of myObject is passed by value to the static method
            //  so we maintain a reference to that object throughout the call stack and any changes 
            //  to the object are propagated up.
            //
            //  However, strings are immutable so when passed by value to a static method
            //  a new copy is created and changes to that string in the static method DO NOT,
            //  propagate back. This is because the copied string goes out of scope when the method exits. 
            //  To maintain a reference to a string into a method we need to explicitly pass
            //  the string by reference with the ref keyword.
            ClassMethod(ref myString, myObject);
        }

        public static void ClassMethod(ref string myString, MyObject myObject)
        {
            myString += "_Updated!";
            myObject.MyNumber = 30;
        }
    }

    class MyObject
    {
        public int MyNumber { get; set; }
    }
}
