using System;
using System.Security.Cryptography;
using System.Text;

namespace Armour
{
    internal class Program
    {
        private static void Main()
        {
            rsaByGenKey(2048, "123");
            rsaByRandomKey("中国人");
        }

        public static void rsaByGenKey(int size, string content)
        {//
            RSASecretKey key = RSAUtils.GenerateRSASecretKey(size);
            string en = RSAUtils.RSAEncrypt(key.PublicKey, content);
            string de = RSAUtils.RSADecrypt(key.PrivateKey, en);
            Console.WriteLine(de);
            Console.ReadKey();
        }

        public static void rsaByRandomKey(string content)
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes(content);
                byte[] encryptedData;
                byte[] decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Pass the data to ENCRYPT, the public key information
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSAUtils.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

                    //Pass the data to DECRYPT, the private key information
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    decryptedData = RSAUtils.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

                    //Display the decrypted plaintext to the console.
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
                Console.ReadKey();
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");
            }
        }
    }
}