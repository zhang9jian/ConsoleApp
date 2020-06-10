using System.Threading;

namespace LogBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // SimpleLogger.WriteMessage("logs", "test");
            QueueLogger.WriteLog("queuelog", QueueLogger.EnumLogLevel.Info);
            QueueLogger.WriteLog("queuelog2", QueueLogger.EnumLogLevel.Info);
            Thread.Sleep(5000);
        }
    }
}