using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeature
{
    internal class Generics
    {
        public void invokeGenericArray()
        {
            GenericArray<int> intArray = new GenericArray<int>(5);
            // 设置值
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }
            // 获取值
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }
            Console.WriteLine();
            // 声明一个字符数组
            GenericArray<char> charArray = new GenericArray<char>(5);
            // 设置值
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c + 97));
            }
            // 获取值
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }
            List<string> arr = new List<string>();
            Console.WriteLine();
            Console.ReadKey();
        }

        public void invokeGenericsMethod()
        {
            int a, b;
            char c, d;
            a = 10;
            b = 20;
            c = 'I';
            d = 'V';

            // 在交换之前显示值
            Console.WriteLine("Int values before calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values before calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);

            // 调用 swap
            GenericsMethod.Swap<int>(ref a, ref b);
            GenericsMethod.Swap<char>(ref c, ref d);

            // 在交换之后显示值
            Console.WriteLine("Int values after calling swap:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values after calling swap:");
            Console.WriteLine("c = {0}, d = {1}", c, d);
            Console.ReadKey();
        }
    }

    //泛型类：允许您延迟编写类或方法中的数据类型
    public class GenericArray<T>
    {
        private T[] array;

        public GenericArray(int size)
        {
            array = new T[size + 1];
        }

        public T getItem(int index)
        {
            return array[index];
        }

        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }

    public class GenericsMethod
    {
        public static void Swap<T2>(ref T2 lhs, ref T2 rhs)
        {
            T2 temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}