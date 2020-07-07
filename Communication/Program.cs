using System;

namespace Communication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = HttpAssist.Get("http://localhost:6699");
            Console.Write(s);
            Console.ReadKey();
        }
    }
}