using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    internal class Property
    {
        public static void execute()
        {
            Person p = new Person();
            p.Name = "a";
            Console.WriteLine(p.Name);
            Person p2 = new Person() { Name = "zhang", Address = "w" };

            Point per = new Point() { X = 0, Y = 0 };
        }
    }

    public class Person
    {
        public string Name //相当于public string Name；对取值和设置没有限制，但还是使用了属性
        {
            get;
            set;
        }

        public string Address //使用属性对字段进行封装，使用value内置值进行判断并赋值
        {
            get { return address; }
            set { if (value.Length < 10) { address = value; } }
        }

        private string address;
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}