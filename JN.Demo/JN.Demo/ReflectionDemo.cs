using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class ReflectionDemo
    {
        public static void Test1()
        {
            var pathToAssembly = string.Empty;

            AppDomain dom = AppDomain.CreateDomain("some");
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.CodeBase = pathToAssembly;
            Assembly assembly = dom.Load(assemblyName);
            Type[] types = assembly.GetTypes();
            AppDomain.Unload(dom);
        }
    }
}
