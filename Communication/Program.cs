using System;

namespace Communication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = HttpAssist.Get("http://220.181.38.150");
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}