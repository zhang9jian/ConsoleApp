using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConvert
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            char i = '1';
            string str = "2";
            Console.WriteLine((int)i);
            Console.WriteLine(int.Parse(str));
            Console.WriteLine(Convert.ToInt32(str));
            Console.ReadLine();
        }
    }
}