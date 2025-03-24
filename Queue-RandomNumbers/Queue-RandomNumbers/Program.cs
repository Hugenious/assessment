using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue_RandomNumbers
{
    class Program
    {
        //Queue to hold random numbers produced by Producer.
        static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        //Random class to generate random numbers.
        static Random randomNumber = new Random();

        //Producer that will be producing the random numbers and add them to the queue.
        static void Producer()
        {
            //Generate 5 random numbers
            for (int i = 1; i<= 5; i++) 
            {
                int num = randomNumber.Next(1, 50); //Generate random number between 1 and 50.
                queue.Enqueue(num); //Add random number to the queue.
                Console.WriteLine("Producer generated number: {0}", num); //Print random number to the console.
            }
        }

        //Consumer that will consume the generated numbers.
        static void Consumer()
        {
            //Check if queue contains elements.
            while (!queue.IsEmpty)
            {
                //Dequeue the next number at the start of the queue
                if (queue.TryDequeue(out int num))
                {
                    Console.WriteLine("Consumer consumed generated number {0}", num); //Print consumed number to the console.
                }
            }
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine("Produced numbers:");
            Console.WriteLine("=================");
            Producer(); //Call producer to generate random numbers and store into the queue

            Console.WriteLine("");
            Console.WriteLine("Consumed numbers:");
            Console.WriteLine("=================");
            Consumer(); //Call consumer to read the stored numbers from the queue


            Console.WriteLine("");
            Console.WriteLine("Process complete.");
            Console.ReadKey(); //Make sure console stays visible to show output.
        }
    }
}
