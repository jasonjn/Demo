using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class AnonymousClassDemo
    {
        /// <summary>
        /// 获取匿名类的属性
        /// </summary>
        public static void Test1()
        {
            var str = GetStudent();
            Console.WriteLine(
                string.Format("Name:{0},Age:{1}", 
                str.GetType().GetProperty("Name").GetValue(str), 
                str.GetType().GetProperty("Age").GetValue(str)));

        }

        public static void Test2()
        {
            for (;;)//无限循环
            {
                Console.WriteLine("1");
            }
                    }

        private static object GetStudent()
        {
            return new { Name = "strTest", Age = 17 };
        }

    }
}
