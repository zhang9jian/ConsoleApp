using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadPool
{
    internal class MultiTask
    {
        /// <summary>
        /// 限制多线程开启数量
        /// </summary>
        public static void LimitThreadCount()
        {
            var maxCount = 10;
            List<int> list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(i);
            }
            Action<int> action = (i) =>
            {
                test();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
                Thread.Sleep(new Random(i).Next(100, 300));
            };

            List<Task> taskList = new List<Task>();
            foreach (var i in list)
            {
                int k = i;

                taskList.Add(Task.Run(() => action.Invoke(k)));
                if (taskList.Count > maxCount)
                {
                    Task.WaitAny(taskList.ToArray());
                    taskList = taskList.Where(at => at.Status != TaskStatus.RanToCompletion).ToList();
                }
            }
            //异步等待其全部执行完毕，不阻塞线程
            Task wTask = Task.WhenAll(taskList.ToArray());
            //wTask.ContinueWith()...

            //死等线程全部执行完毕，阻塞后面的线程
            Task.WaitAll(taskList.ToArray());
        }

        public static string test()
        {
            Console.WriteLine("test");
            return "";
        }
    }
}