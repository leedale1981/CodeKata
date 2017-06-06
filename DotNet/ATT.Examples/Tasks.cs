using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT.Examples
{
    public class Tasks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Asynchronous:");
            Console.WriteLine("");
            Task task = new Task(delegate()
                {
                    for (int index = 0; index < 100000; index++)
                    {
                        Console.WriteLine("Async Line: " + index.ToString());
                        Random random = new Random();
                        int randomCalc = random.Next() + random.Next();
                        Console.WriteLine("Random number: " + randomCalc.ToString());
                    }
                });

            task.Start();

            task.ContinueWith(delegate(Task newTask)
            {
                for (int index = 0; index < 100000; index++)
                {
                    Console.WriteLine("Continued Line: " + index.ToString());
                }
            });

            Console.WriteLine("Synchronous:");
            Console.WriteLine("");
            for (int index = 0; index < 100000; index++)
            {
                Console.WriteLine("Sync Line: " + index.ToString());
                Random random = new Random();
                int randomCalc = random.Next() + random.Next();
                Console.WriteLine("Random number: " + randomCalc.ToString());
            }

            task.Wait();
        }

        
    }
}
