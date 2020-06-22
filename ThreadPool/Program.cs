using System;

namespace SimpleThreadPool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*ThreadQ tq = new ThreadQ();
            tq.execute();
            Console.ReadKey();
            */
            //TaskDemo.taskDemo();
            MultiTask.LimitThreadCount();
            /*ThreadWaitForSingleObj.execute();*/
            Console.ReadKey()；
        }
    }
}