using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NewFeature
{
    internal class AnonymousObject
    {
        private object getAnonymoutObject()
        {
            var a = new { id = 1, AddressFamily = "beijing" };
            return a;
        }

        private void invokeGetAnonymousObj()
        {
            var b = getAnonymoutObject();
            //可以通过c#的反射机制取值
            string str = b.GetType().GetProperty("AddressFamily").GetValue(b).ToString();
            Console.WriteLine(str);
        }
    }
}