using System;

namespace Armour
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RSAUtils rsa = new RSAUtils();
            string en =  rsa.RSAEncrypt(rsa.GenerateRSASecretKey(256).PublicKey, "我的咪咪");
            Console.WriteLine(rsa.RSADecrypt(rsa.GenerateRSASecretKey(256).PrivateKey, en));
            Console.ReadKey();
        }
    }
}