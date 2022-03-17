using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    
    public class Program
    {
        static int number = 0;

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            { 
                Interlocked.Increment(ref number);
                //number++;
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);
                //number--;
            }
        }

        public static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}