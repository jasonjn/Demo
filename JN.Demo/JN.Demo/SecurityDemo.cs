using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace JN.Demo
{
   public  class SecurityDemo
    {
        public static void Test1()
        {
            var CertFile_Private = @"D:\URLEncode.pfx";
            var CertFile_Public = @"D:\URLEncode.cer";
            var password = @"PC~2008M@re26";

            var instance = Crypto.Instance(CertFile_Public, CertFile_Private, password);

           var str= instance.RSAEncrypt("jn");
            var jn=instance.RSADecrypt(str);

            if (jn.Equals("jn"))
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }

      

    }


    public class Crypto
    {
        private static Crypto _instance;
        public static Crypto Instance(string CertFile_Public,string CertFile_Private ,string password )
        {
            if (_instance==null)
            {
                _instance= new Crypto()
                {
                    CertFile_Public = CertFile_Public,
                    CertFile_Private=CertFile_Private,
                    Password = password
                };
            }
            return _instance;
        }

        public static void Clear()
        {
            _instance = null;
        }

        public string CertFile_Public { get; private set; }

        public string CertFile_Private { get; private set; }

        public string Password { get; private set; }


        public string RSAEncrypt(string input)
        {
            return Convert.ToBase64String(RSAEncrypt(Encoding.UTF8.GetBytes(input),CertFile_Public));
        }

        public string RSADecrypt(string cryptText)
        {
            return Encoding.UTF8.GetString(RSADecrypt(Convert.FromBase64String(cryptText),  CertFile_Private,  Password));
        }


        private  Byte[] RSAEncrypt(Byte[] plainTextByte, string filename)
        {
            X509Certificate2 myX509Certificate2 = new X509Certificate2(filename);
            RSACryptoServiceProvider myRSACryptoServiceProvider = (RSACryptoServiceProvider)myX509Certificate2.PublicKey.Key;
            return myRSACryptoServiceProvider.Encrypt(plainTextByte, false);
        }

        private byte[] RSADecrypt(byte[] cryptText, string fileName, string password)
        {
            X509Certificate2 myX509Certificate2 = new X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet);
            RSACryptoServiceProvider myRSACryptoServiceProvider = (RSACryptoServiceProvider)myX509Certificate2.PrivateKey;
            return myRSACryptoServiceProvider.Decrypt(cryptText, false);
        }
    }
}
