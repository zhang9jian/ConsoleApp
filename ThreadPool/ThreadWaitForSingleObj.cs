using System;
using System.Threading;

namespace SimpleThreadPool
{
    // TaskInfo contains data that will be passed to the callback method.
    public class TaskInfo
    {
        public RegisteredWaitHandle Handle = null;
        public string OtherInfo = "default";
    }

    internal class ThreadWaitForSingleObj
    {
        public static void execute()
        {
            // 主线程使用AutoResetEvent来给已注册的等待句柄发信号, 此等待句柄执行回调方法
            AutoResetEvent ev = new AutoResetEvent(false);

            TaskInfo ti = new TaskInfo();
            ti.OtherInfo = "First task";
            // 该任务的TaskInfo包括RegisterWaitForSingleObject返回的已注册的等待句柄。
            //这允许在对象被发出一次信号时终止等待(参见WaitProc)。
            ti.Handle = ThreadPool.RegisterWaitForSingleObject(
                ev,
                new WaitOrTimerCallback(WaitProc),
                ti,
                1000,
                false
            );

            // 主线程等待三秒,为了演示队列中的线程超时，然后发信号.
            Thread.Sleep(20000);
            Console.WriteLine("Main thread signals.");
            ev.Set();//发信号

            // 主线程休眠，这应该给回调方法执行的时间。如果注释掉这一行，程序通常会在ThreadPool线程执行之前结束。
            Thread.Sleep(1000);
        }

        //当注册的等待时间超时，或者WaitHandle(在本例中是AutoResetEvent)发出信号时，回调方法执行。
        //WaitProc在事件第一次发出信号时注销WaitHandle。.
        public static void WaitProc(object state, bool timedOut)
        {
            TaskInfo ti = (TaskInfo)state;

            string cause = "TIMED OUT";
            if (!timedOut) //如果Timeout为false，表示接收到的信号后执行的
            {
                cause = "SIGNALED";
                //如果回调方法执行是因为WaitHandle触发信号的话，则用反注册等待句柄来取消回调方法将来的执行。即不在线程池中注册了
                if (ti.Handle != null)
                    ti.Handle.Unregister(null);
            }

            Console.WriteLine("WaitProc( {0} ) executes on thread {1}; cause = {2}.",
                ti.OtherInfo, Thread.CurrentThread.GetHashCode().ToString(), cause);//超时后执行的
        }
    }
}