using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class DelegateDemo
    {
        public static void Test1()
        {
            Action action = () => { Console.WriteLine("action"); };
            action();
        }

    }
}
