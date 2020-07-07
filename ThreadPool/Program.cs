using System;
using System.Threading;

namespace SimpleThreadPool
{
    internal class Program
    {
        private long j = 0;

        private static void Main(string[] args)
        {
            ThreadQ tq = new ThreadQ();
            tq.execute();
            Console.ReadKey();

            //TaskDemo.taskDemo();
            // MultiTask.LimitThreadCount();
            /*ThreadWaitForSingleObj.execute();*/
            // new Program().startThread();
            Console.ReadKey();
        }

        public void startThread()
        {
            //for (int i = 0; i < 10; i++)
            //  {
            Thread t1 = new Thread(new ThreadStart(cal));
            Thread t2 = new Thread(new ThreadStart(cal));

            t1.Start();
            t2.Start();
            //}
        }

        public void cal()
        {
            long k = 1L;
            for (int i = 0; i < 1000000; i++)
            {
                k += i;
                j += i;
            }
            Console.WriteLine("The result is :" + k);
            Console.WriteLine("The clall result is :" + j);
        }
    }
}