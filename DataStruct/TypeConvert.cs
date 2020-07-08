using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct
{
    internal class TypeConvert
    {
        public void execute()
        {
            byte[] Test_byte = new byte[] { 0, 1, 2, 3 };
            byte[] Temp_byte;
            bool Test_bool;
            int Test_int;
            float Test_float;
            char Test_char;
            string Test_string;

            //byte 2 bool
            //返回由字节数组中指定位置的一个字节转换来的布尔值。
            //public static bool ToBoolean(byte[] value, int startIndex);
            Test_bool = BitConverter.ToBoolean(Test_byte, 1);
            Console.WriteLine("bool is: {0}", Test_bool.ToString());

            //bool 2 byte
            //以字节数组的形式返回指定的布尔值。
            //public static byte[] GetBytes(bool value);
            Temp_byte = BitConverter.GetBytes(Test_bool);
            Console.WriteLine("bool length is: {0}", Temp_byte.Length);

            //byte 2 int
            //返回由字节数组中指定位置的四个字节转换来的 32 位有符号整数。
            //public static int ToInt32(byte[] value, int startIndex);
            Test_int = BitConverter.ToInt32(Test_byte, 0);
            Console.WriteLine("int is: {0}", Test_int);

            //int 2 byte
            //以字节数组的形式返回指定的 32 位有符号整数值。
            //public static byte[] GetBytes(int value);
            Temp_byte = BitConverter.GetBytes(Test_int);
            Console.WriteLine("int length is: {0}", Temp_byte.Length);

            //byte 2 float
            //返回由字节数组中指定位置的四个字节转换来的单精度浮点数。
            //public static float ToSingle(byte[] value, int startIndex);
            Test_float = BitConverter.ToSingle(Test_byte, 0);
            Console.WriteLine("float is: {0}", Test_float);

            //float 2 byte
            //以字节数组的形式返回指定的单精度浮点值。
            //public static byte[] GetBytes(float value);
            Temp_byte = BitConverter.GetBytes(Test_float);
            Console.WriteLine("float length is: {0}", Temp_byte.Length);

            //byte 2 char
            //返回由字节数组中指定位置的两个字节转换来的 Unicode 字符。
            //public static char ToChar(byte[] value, int startIndex);
            Test_char = BitConverter.ToChar(Test_byte, 0);
            Console.WriteLine("char is: {0}", Test_char);

            //char 2 byte
            //以字节数组的形式返回指定的 Unicode 字符值。
            //public static byte[] GetBytes(char value);
            Temp_byte = BitConverter.GetBytes(Test_char);
            Console.WriteLine("char length is: {0}", Temp_byte.Length);

            //byte 2 string
            //将指定的字节子数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
            //public static string ToString(byte[] value, int startIndex);
            Test_string = BitConverter.ToString(Test_byte, 0);
            Console.WriteLine("string is: {0}", Test_string);

            //string 2 byte
            //在派生类中重写时，将指定的 System.String 中的所有字符编码为一个字节序列。
            //public virtual byte[] GetBytes(string s);
            Temp_byte = Encoding.Default.GetBytes(Test_string);
            Console.WriteLine("string length is: {0}", Temp_byte.Length);

            //char test
            char Test_c1 = '人';
            char Test_c2 = '1';
            Temp_byte = BitConverter.GetBytes(Test_c1);
            Console.WriteLine("Byte characters occupy is: {0}", Temp_byte.Length);
            Temp_byte = BitConverter.GetBytes(Test_c2);
            Console.WriteLine("Byte digital occupy is: {0}", Temp_byte.Length);

            //string test
            string Test_str1 = "人";
            string Test_str2 = "1";
            Temp_byte = Encoding.Default.GetBytes(Test_str1);
            Console.WriteLine("Byte characters occupy is: {0}", Temp_byte.Length);
            Temp_byte = Encoding.Default.GetBytes(Test_str2);
            Console.WriteLine("Byte digital occupy is: {0}", Temp_byte.Length);
        }
    }
}