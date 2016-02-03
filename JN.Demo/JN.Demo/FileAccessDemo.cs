using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class FileAccessDemo
    {
        public static void test1()
        {
           
            try
            {
                  var filepath = @"D:\testest";           
                var fileSecurity = File.GetAccessControl(filepath);             
                fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));          
                File.SetAccessControl(filepath,fileSecurity);
            }
            catch  
            {
               
            }
    
           
            
        }
    }
}
