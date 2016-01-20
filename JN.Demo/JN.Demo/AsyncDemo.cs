using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JN.Demo
{
    class AsyncDemo
    {
        public static void test1()
        {
            AsyncMethodLib.GetValueAsync(1d, 2d);

            Console.WriteLine("MyClass() End.");
        }


        public static void test2()
        {
            SayHelloMethod sayHelloMethod = AsyncMethodLib.SayHello;
            sayHelloMethod.BeginInvoke(
                 (sr) => {
                     var srr = sr as AsyncResult;

                     var sayhelloMethod = (SayHelloMethod)srr.AsyncDelegate;

                     var result = sayHelloMethod.EndInvoke(sr);

                     Console.WriteLine(result);
                 }, null
                );
        }

        public static async void test3()
        {
            double result = await AsyncMethodLib.GetValueAsync(1234.5d, 1.01d);

            Console.WriteLine(string.Format("Value is : {0}", result));
        }

    }




    public delegate string SayHelloMethod();



    public class AsyncTest : IAsyncResult
    {
        public object AsyncState
        {
            get { throw new NotImplementedException(); }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        public bool CompletedSynchronously
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCompleted
        {
            get { throw new NotImplementedException(); }
        }
    }



    public class AsyncMethodLib
    {
        public static Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(new TimeSpan(0, 0, 10));
                return num1 + num2;
            });
        }
        public static string SayHello()
        {
            return "Hello";
        }

    }
}

