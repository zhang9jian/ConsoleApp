using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeature
{
    internal class Default
    {
        //变量赋值
        private string s = default;

        private int i = default;
        private DateTime? dt = default;
        private dynamic d = default;
        private int i;

        //表达式默认值
        public string A => default;

        //方法形参可选参数赋值
        private void Test(int a, string b = default)
        {
        }

        //方法调用
        public void execute()
        {
            Test(default, default);
        }

        //返回语句
        private static string Test()
        {
            return default;
        }
    }
}