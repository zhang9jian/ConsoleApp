using System;
using System.Threading;

namespace Delegate
{
    internal class DelegateAsyncResult
    {
        private delegate string MyDelegate(string name, int age);

        public static void execute()
        {
            MyDelegate myDelegate = new MyDelegate(GetString);

            IAsyncResult result = myDelegate.BeginInvoke("刘备", 22, null, null);

            Console.WriteLine("主线程继续工作!");
            WaitHandle[] waitHandleList = new WaitHandle[] { result.AsyncWaitHandle };
            //是否全部异步线程完成
            while (!WaitHandle.WaitAll(waitHandleList, 200))
            {
                Console.WriteLine("异步线程未全部完成，主线程继续干其他事!");
            }
            /*
            while (!result.IsCompleted)
            {
                Thread.Sleep(500);
                Console.WriteLine("异步线程还没完成，主线程干其他事!");
            }

            //比上个例子，判断条件由IsCompleted属性换成了AsyncWaitHandle，仅此而已
            while (!result.AsyncWaitHandle.WaitOne(200))
            {
                Console.WriteLine("异步线程没完，主线程继续干活！");
            }
            //是否完成了指定数量
            WaitHandle[] waitHandleList = new WaitHandle[] { result.AsyncWaitHandle };
            while (WaitHandle.WaitAny(waitHandleList, 200) > 0)
            {
                Console.WriteLine("异步线程完成数未大于0，主线程继续甘其他事!");
            }
            WaitHandle[] waitHandleList = new WaitHandle[] { result.AsyncWaitHandle };
            //是否全部异步线程完成
            while (!WaitHandle.WaitAll(waitHandleList, 200))
            {
                Console.WriteLine("异步线程未全部完成，主线程继续干其他事!");
            }
            */
            string data = myDelegate.EndInvoke((System.IAsyncResult)result);
            Console.WriteLine(data);

            Console.ReadKey();
        }

        private static string GetString(string name, int age)
        {
            Thread.Sleep(2000); return string.Format("我是{0}，今年{1}岁!", name, age);
        }
    }
}