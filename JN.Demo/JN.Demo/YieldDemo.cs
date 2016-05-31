using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
  public  class YieldDemo
    {
        public static void Test1()
        {
            foreach (var item in GetNumber())
            {
                Console.WriteLine(item);
            }
        

        }


        public static IEnumerable<int> GetNumber()
        {
            foreach (int i in new int[] { 1, 2, 3, 5, 8 })
            {
                yield return i;
                yield break;
            }
        }
    }
}
