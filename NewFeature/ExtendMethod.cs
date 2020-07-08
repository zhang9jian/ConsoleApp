using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 1、创建一个静态类；
2、在其中创建一个静态方法；
3、为这个静态方法添加至少一个参数，并在第一个参数前加上this关键字，
   这个关键字会告诉编译器当前方法是一个扩展方法。而这个方法将成为第一个参数所属类型的新成员。
 */

namespace DataStruct
{
    public static class Int32Extension
    {
        public static string FormatForMoney(this int Value)
        {
            return Value.ToString("$###,###,###,##0");
        }
    }

    public static class DoubleExtension
    {
        public static string FormatPercent(this double Value)
        {
            return Value.ToString("0.00%");
        }
    }

    internal class ExtendMethod
    {
        public static void execute()
        {
            int money = 12456789;
            double p = 0.123456;

            Console.WriteLine("{0}", money.FormatForMoney());
            Console.WriteLine("{0}", p.FormatPercent());
        }
    }
}