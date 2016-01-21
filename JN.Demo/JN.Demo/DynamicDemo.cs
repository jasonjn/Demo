using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JN.Demo
{
    class DynamicDemo
    {
        public static void test1()
        {
            var model = GetDynamicModel();
            model.ShowName();
        }

        private static dynamic GetDynamicModel()
        {
            dynamic model = new ExpandoObject();
            model.Name = "JN";
            model.ShowName =new Action(() => Console.WriteLine(model.Name));
            return model;
        }
    }
}
