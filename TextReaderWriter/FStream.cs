using System;
using System.IO;
using System.Text;

namespace TextReaderWriter
{
    internal class FStream
    {
        public static void writeSingleByte(string filepath, byte data)
        {
            FileStream F = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            F.WriteByte(data);
            F.Close();
        }

        public static byte readSingleByte(string filepath)
        {
            FileStream F = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            F.Position = 0;
            byte data = (byte)F.ReadByte();
            F.Close();
            return data;
        }

        public static void writeByteArray(string filePath, string text)
        {
            //FileMode.Append为不覆盖文件效果.create为覆盖
            FileStream fs = new FileStream(filePath, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(text);
            //开始写入
            Console.WriteLine("write byte : " + data.Length);
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public static byte[] readByteArray(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            long fileLength = file.Length;
            byte[] byteData = new byte[fileLength];
            Console.WriteLine("readbytearrry: " + byteData.Length);
            file.Seek(0, SeekOrigin.Begin);
            file.Read(byteData, 0, byteData.Length);
            file.Close();
            return byteData;
        }

        public static char[] byteArrayToCharArray(byte[] data)
        {
            char[] charData = new char[data.Length];
            Console.WriteLine("chararray: " + charData.Length);
            Decoder d = Encoding.Default.GetDecoder();
            d.GetChars(data, 0, data.Length, charData, 0);
            return charData;
        }
    }
}