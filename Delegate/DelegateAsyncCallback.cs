using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Delegate
{
    internal class DelegateAsyncCallback
    {
        private delegate string MyDelegate(string name, int age);

        public static void execute()
        {
            Person p = new Person(2, "关羽");

            //建立委托
            MyDelegate myDelegate = new MyDelegate(GetString);
            //最后一个参数的作用，原来是用来传参的
            IAsyncResult result1 = myDelegate.BeginInvoke("刘备", 23, new AsyncCallback(Completed), p);
            //主线程可以继续工作而不需要等待
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("我是主线程，我干我的活，不再理你！");
                Thread.Sleep(1000);
            }
            Console.ReadKey();
        }

        private static string GetString(string name, int age)
        {
            Thread.CurrentThread.Name = "异步线程";
            //注意，如果不设置为前台线程，则主线程完成后就直接卸载程序了
            Thread.CurrentThread.IsBackground = false;
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }

        //供异步线程完成回调的方法
        private static void Completed(IAsyncResult result)
        {
            AsyncResult _result = (AsyncResult)result;
            //获取委托对象，调用EndInvoke方法获取运行结果
            MyDelegate myDelegaate = (MyDelegate)_result.AsyncDelegate;
            //获得参数
            string data = myDelegaate.EndInvoke(_result);
            Console.WriteLine(data);

            Person p = result.AsyncState as Person;
            Console.WriteLine("传过来的参数是：" + p.Name);
            //异步线程执行完毕
            Console.WriteLine("异步线程完成咯！");
            Console.WriteLine("回调函数也是由" + Thread.CurrentThread.Name + "调用的！");
        }
    }

    public class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}