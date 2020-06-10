using System;

namespace Armour
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RSAUtils rsaUtils = new RSAUtils();
            RSAUtils.RSASecretKey rsaKey = rsaUtils.GenerateRSASecretKey(1024);
            string en = rsaUtils.RSAEncrypt(rsaKey.PublicKey, "我的咪咪");
            Console.WriteLine(rsaUtils.RSADecrypt(rsaKey.PrivateKey, en));
            Console.ReadKey();
        }
    }
}