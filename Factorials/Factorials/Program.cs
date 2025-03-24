using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Factorials
{
    class Program
    {
        static readonly object objlock = new object();

        private static void Main(string[] args)
        {
            //Array of numbers to calculate Factorials.
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Thread list.
            List<Thread> threadList = new List<Thread>();


            foreach (int number in numbers)
            {
                //Thread to call the CalculateFactorial method with number as parameter.
                Thread factorialThread = new Thread(() => CalculateFactorial(number));
                //Add threads to a thread list
                threadList.Add(factorialThread);
                factorialThread.Start(); //Start the thread.
            }

            foreach (Thread singleThread in threadList)
            {
                //Join all threads and wait for threads to end before continuing.
                singleThread.Join();
            }
        }

        //Function to calculate the factorial accepting integer as parameter.
        private static void CalculateFactorial(int number)
        {
            int factorialResult = 1;
            for (int i = number; i >= 2; i--) //No need to calculate x1.
            {
                factorialResult *= i; //Calculate actual factorial.
            }

            lock (objlock) //Lock the current object to execute the Console output and release the lock.
            {
                Console.WriteLine(string.Format("Factorial of {0} is {1}.", number, factorialResult));
            }
        }
    }
}
