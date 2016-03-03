using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JN.Demo
{
    class SortDemo
    {
        public static void Test1()
        {
            string[] arr = { "3", "1", "2", "b", "c", "a", "BB", "A", "C", "阿尔巴尼亚", "一刀切", "二刀切", "三刀切" };
            //发音 LCID：0x00000804
            CultureInfo PronoCi = new CultureInfo(2052);
            
            Array.Sort(arr);

            Console.WriteLine("按发音排序:");
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                Console.WriteLine("[{0}]:/t{1}", i, arr.GetValue(i));

            Console.WriteLine();
            //笔画数 LCID：0x00020804
            CultureInfo StrokCi = new CultureInfo(133124);

            Thread.CurrentThread.CurrentCulture = StrokCi;

            Array.Sort(arr);

            Console.WriteLine("按笔划数排序:");
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
                Console.WriteLine("[{0}]:/t{1}", i, arr.GetValue(i));
        }

    }
}
