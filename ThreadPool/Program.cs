using System;

namespace SimpleThreadPool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ThreadQ tq = new ThreadQ();
            tq.execute();
            Console.ReadKey();

            /*ThreadWaitForSingleObj.execute();
            Console.ReadKey();*/
        }
    }
}