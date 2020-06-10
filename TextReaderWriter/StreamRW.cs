using System;
using System.IO;

namespace TextReaderWriter
{
    internal class StreamRW
    {
        public static void ReadLine(string filepath)
        {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;

                    // 从文件读取并显示行，直到文件的末尾
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void WriteLine(string filepath)
        {
            string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
            }

            // 从文件中读取并显示每行
            string line = "";
            using (StreamReader sr = new StreamReader(filepath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }

        public static string readAllText(string filePath)
        {
            string text = System.IO.File.ReadAllText(filePath);

            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            return text;
        }

        public static string[] readAllLines(string filePath)
        {
            string[] text = System.IO.File.ReadAllLines(filePath);

            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            return text;
        }

        public static void writeAllText(string filePath, string contents)
        {
            File.WriteAllText(filePath, contents);
        }

        public static void writeAllLines(string filePath, string[] contents)
        {
            File.WriteAllLines(filePath, contents);
        }
    }
}