using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class Cert
    {
        public void Test1()
        {
            //生成pfx证书文件
            string MakeCert = "D:\\makecert.exe";
            string x509Name = "CN=111";
            string param = " -pe -ss my -n \"" + x509Name + "\" ";
            Process p = Process.Start(MakeCert, param);
            p.WaitForExit();
            p.Close();

            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == "CN=111")
                {
                    Debug.Print(string.Format("certificate name: {0}", x509.Subject));
                    byte[] pfxByte = x509.Export(X509ContentType.Pfx, "Konn@PP16");
                    FileStream fileStream = new FileStream(Path.Combine("D:\\", "Konn.pfx"), FileMode.Create);

                    // Write the data to the file, byte by byte.   
                    for (int i = 0; i < pfxByte.Length; i++)
                        fileStream.WriteByte(pfxByte[i]);
                    // Set the stream position to the beginning of the file.   
                    fileStream.Seek(0, SeekOrigin.Begin);
                    // Read and verify the data.   
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (pfxByte[i] != fileStream.ReadByte())
                        {
                            return;
                        }
                    }
                    fileStream.Close();
                }
            }
            store.Close();
            store = null;
            storecollection = null;
        }
    }
}
