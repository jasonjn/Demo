using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cert.Test1();
            //SecurityDemo.Test1();
            //DynamicDemo.test2();            

            YieldDemo.Test1();
            Console.ReadLine();
        }
        List<int> array = new List<int> { 1, 2, 3, 4, 5 };
        void foreachDemo()
        {     

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        void forDemo()
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        void LinqDemo()
        {
            array.ToList().ForEach(o => Console.WriteLine(o));
        }

    }
}
