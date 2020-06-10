using System;
using System.Threading;

namespace SimpleThreadPool
{
    public class Person
    {
        public Person(int id, string name)
        {
            Id = id; Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ThreadQ
    {
        public void execute()
        {
            Person p = new Person(1, "刘备");
            //启动工作者线程
            for (int i = 0; i < 100; i++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(RunWorkerThread), p);
            Console.WriteLine("线程放置完成，立即执行！");
        }

        private void RunWorkerThread(object obj)
        {
            Person p = obj as Person;
            Thread.Sleep(200);
            Console.WriteLine("线程池线程开始!" + p.Name);
        }
    }
}