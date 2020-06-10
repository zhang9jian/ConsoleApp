using System;

namespace XML
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlParser xmlParser = new XmlParser();
            xmlParser.parse();
            Console.ReadKey();
        }
    }
}