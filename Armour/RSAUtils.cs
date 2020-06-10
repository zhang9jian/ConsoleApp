using System;
using System.Security.Cryptography;
using System.Text;

namespace Armour
{
    internal class RSAUtils
    {
        public struct RSASecretKey
        {
            public RSASecretKey(string privateKey, string publicKey)
            {
                PrivateKey = privateKey;
                PublicKey = publicKey;
            }

            public string PublicKey { get; set; }
            public string PrivateKey { get; set; }

            public override string ToString()
            {
                return string.Format("PrivateKey: {0} PublicKey: {1}", PrivateKey, PublicKey);
            }
        }

        public RSASecretKey GenerateRSASecretKey(int keySize)

        {
            RSASecretKey rsaKey = new RSASecretKey();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))

            {
                rsaKey.PrivateKey = rsa.ToXmlString(true);

                rsaKey.PublicKey = rsa.ToXmlString(false);
            }

            return rsaKey;
        }

        public string RSAEncrypt(string xmlPublicKey, string content)
        {
            string encryptedContent = string.Empty;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPublicKey);
                byte[] encryptedData = rsa.Encrypt(Encoding.Default.GetBytes(content), false);
                encryptedContent = Convert.ToBase64String(encryptedData);
            }
            return encryptedContent;
        }

        public string RSADecrypt(string xmlPrivateKey, string content)

        {
            string decryptedContent = string.Empty;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())

            {
                rsa.FromXmlString(xmlPrivateKey);

                byte[] decryptedData = rsa.Decrypt(Convert.FromBase64String(content), false);

                decryptedContent = Encoding.GetEncoding("gb2312").GetString(decryptedData);
            }

            return decryptedContent;
        }
    }
}