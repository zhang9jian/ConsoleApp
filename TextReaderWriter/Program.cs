using System;

namespace TextReaderWriter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //  EnvVariable.retrieveEnvVar();
            FStream.writeSingleByte("1.txt", (byte)1);
            byte a = FStream.readSingleByte("1.txt");
            Console.WriteLine(a);
            FStream.writeByteArray("2.txt", "我是中国人");
            char[] b = FStream.byteArrayToCharArray(FStream.readByteArray("2.txt"));
            Console.WriteLine(b);
            Console.ReadKey();
            //  FStream.readByByte("b.dat");
            // StreamRW.WriteLine("a.dat");
        }
    }
}