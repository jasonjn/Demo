using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
   public class StringDemo
    {
        public static void Test1()
        {
            var array = new[] { "a", "b", "c", "d", "e" };

             
            var result = array.Aggregate( new StringBuilder(), (a,n) =>
            {
                a.Append(n + ",");
                return a;
            });
            Console.WriteLine(result.ToString().TrimEnd(','));
        }

    }
}
