using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Basic
    {
        //定义方法
        public static void Book(string str)
        {
            Console.WriteLine(str);
        }
        //定义同方法签名的委托
        private delegate void BuyBook(string str);


        public static string FuncBook(string str)
        {
            return str;
        }
        public  void execute()
        {
            //委托起始的使用方法：
            //定义方法，定义同方法签名的委托，初始化委托实例，使用委托
            BuyBook buybook = new BuyBook(Book);
            buybook("委托初始使用方法");

            //使用Action内置委托
            Action<string> BookAction = new Action<string>(Book);
            BookAction("使用Action内置委托");
            //使用Func内置委托，含返回值
            Func<string, string> RetBook = new Func<string, string>(FuncBook);
            Console.WriteLine(RetBook("使用Func内置委托，含返回值"));

            //内置委托和匿名委托，同action
            Func<string,string> funcAnnoyDelegate = delegate(string str)
            {
                return "匿名委托定义的方法"+str;
            };

            Console.WriteLine(funcAnnoyDelegate("funcValue"));

            //内置委托和lamda表达式
            Func<string, string> funcLamda = (str)=>
            {
                return "匿名委托定义的方法" + str;
            };
            Console.WriteLine(funcLamda("funcLamda"));
        }




    }
}
