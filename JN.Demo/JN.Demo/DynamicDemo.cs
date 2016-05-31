using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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


        public static void test2()
        {
            // Create an array that specifies the types of the parameters
            // of the dynamic method. This dynamic method has a String
            // parameter and an Integer parameter.
            Type[] helloArgs = { typeof(string), typeof(int) };

            // Create a dynamic method with the name "Hello", a return type
            // of Integer, and two parameters whose types are specified by
            // the array helloArgs. Create the method in the module that
            // defines the String class.
            DynamicMethod hello = new DynamicMethod("Hello",
                typeof(int),
                helloArgs,
                typeof(string).Module);

            // Create an array that specifies the parameter types of the
            // overload of Console.WriteLine to be used in Hello.
            Type[] writeStringArgs = { typeof(string) };
            // Get the overload of Console.WriteLine that has one
            // String parameter.
            MethodInfo writeString = typeof(Console).GetMethod("WriteLine",
                writeStringArgs);

            // Get an ILGenerator and emit a body for the dynamic method,
            // using a stream size larger than the IL that will be
            // emitted.
            ILGenerator il = hello.GetILGenerator(256);
            // Load the first argument, which is a string, onto the stack.
            il.Emit(OpCodes.Ldarg_0);
            // Call the overload of Console.WriteLine that prints a string.
            il.EmitCall(OpCodes.Call, writeString, null);
            // The Hello method returns the value of the second argument;
            // to do this, load the onto the stack and return.
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ret);

            // Add parameter information to the dynamic method. (This is not
            // necessary, but can be useful for debugging.) For each parameter,
            // identified by position, supply the parameter attributes and a 
            // parameter name.
            hello.DefineParameter(1, ParameterAttributes.In, "message");
            hello.DefineParameter(2, ParameterAttributes.In, "valueToReturn");

            // Create a delegate that represents the dynamic method. This
            // action completes the method. Any further attempts to
            // change the method are ignored.
            HelloDelegate hi =
                (HelloDelegate)hello.CreateDelegate(typeof(HelloDelegate));

            // Use the delegate to execute the dynamic method.
            Console.WriteLine("\r\nUse the delegate to execute the dynamic method:");
            int retval = hi("\r\nHello, World!", 42);
            Console.WriteLine("Invoking delegate hi(\"Hello, World!\", 42) returned: " + retval);

            // Execute it again, with different arguments.
            retval = hi("\r\nHi, Mom!", 5280);
            Console.WriteLine("Invoking delegate hi(\"Hi, Mom!\", 5280) returned: " + retval);

            Console.WriteLine("\r\nUse the Invoke method to execute the dynamic method:");
            // Create an array of arguments to use with the Invoke method.
            object[] invokeArgs = { "\r\nHello, World!", 42 };
            // Invoke the dynamic method using the arguments. This is much
            // slower than using the delegate, because you must create an
            // array to contain the arguments, and value-type arguments
            // must be boxed.
            object objRet = hello.Invoke(null, BindingFlags.ExactBinding, null, invokeArgs, new CultureInfo("en-us"));
            Console.WriteLine("hello.Invoke returned: " + objRet);

            Console.WriteLine("\r\n ----- Display information about the dynamic method -----");
            // Display MethodAttributes for the dynamic method, set when 
            // the dynamic method was created.
            Console.WriteLine("\r\nMethod Attributes: {0}", hello.Attributes);

            // Display the calling convention of the dynamic method, set when the 
            // dynamic method was created.
            Console.WriteLine("\r\nCalling convention: {0}", hello.CallingConvention);

            // Display the declaring type, which is always null for dynamic
            // methods.
            if (hello.DeclaringType == null)
            {
                Console.WriteLine("\r\nDeclaringType is always null for dynamic methods.");
            }
            else
            {
                Console.WriteLine("DeclaringType: {0}", hello.DeclaringType);
            }

            // Display the default value for InitLocals.
            if (hello.InitLocals)
            {
                Console.Write("\r\nThis method contains verifiable code.");
            }
            else
            {
                Console.Write("\r\nThis method contains unverifiable code.");
            }
            Console.WriteLine(" (InitLocals = {0})", hello.InitLocals);

            // Display the module specified when the dynamic method was created.
            Console.WriteLine("\r\nModule: {0}", hello.Module);

            // Display the name specified when the dynamic method was created.
            // Note that the name can be blank.
            Console.WriteLine("\r\nName: {0}", hello.Name);

            // For dynamic methods, the reflected type is always null.
            if (hello.ReflectedType == null)
            {
                Console.WriteLine("\r\nReflectedType is null.");
            }
            else
            {
                Console.WriteLine("\r\nReflectedType: {0}", hello.ReflectedType);
            }

            if (hello.ReturnParameter == null)
            {
                Console.WriteLine("\r\nMethod has no return parameter.");
            }
            else
            {
                Console.WriteLine("\r\nReturn parameter: {0}", hello.ReturnParameter);
            }

            // If the method has no return type, ReturnType is System.Void.
            Console.WriteLine("\r\nReturn type: {0}", hello.ReturnType);

            // ReturnTypeCustomAttributes returns an ICustomeAttributeProvider
            // that can be used to enumerate the custom attributes of the
            // return value. At present, there is no way to set such custom
            // attributes, so the list is empty.
            if (hello.ReturnType == typeof(void))
            {
                Console.WriteLine("The method has no return type.");
            }
            else
            {
                ICustomAttributeProvider caProvider = hello.ReturnTypeCustomAttributes;
                                                                                                                                              object[] returnAttributes = caProvider.GetCustomAttributes(true);
                if (returnAttributes.Length == 0)
                {
                    Console.WriteLine("\r\nThe return type has no custom attributes.");
                }
                else
                {
                    Console.WriteLine("\r\nThe return type has the following custom attributes:");
                    foreach (object attr in returnAttributes)
                    {
                        Console.WriteLine("\t{0}", attr.ToString());
                    }
                }
            }

            Console.WriteLine("\r\nToString: {0}", hello.ToString());

            // Display parameter information.
            ParameterInfo[] parameters = hello.GetParameters();
            Console.WriteLine("\r\nParameters: name, type, ParameterAttributes");
            foreach (ParameterInfo p in parameters)
            {
                Console.WriteLine("\t{0}, {1}, {2}",
                    p.Name, p.ParameterType, p.Attributes);
            }
        }

        public static void test3()
        {
            DynamicMethod dm = new DynamicMethod("Test", null,
             new Type[] { typeof(string) }, typeof(string).Module);
            ILGenerator il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);//把参数推到堆栈上
            MethodInfo call = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            il.Emit(OpCodes.Call, call);//执行Console.WriteLine方法
            il.Emit(OpCodes.Ret);//结束返回
            Action<string> test = (Action<string>)dm.CreateDelegate(typeof(Action<string>));
            test("henry");

            //下面Test1方法和Test完成的方法是一样的,但IL似乎有些不同.
            //主要体现变量设置,对于变量的位置也会影响指令
            dm = new DynamicMethod("Test1", null,
                new Type[] { typeof(string) }, typeof(string).Module);
            il = dm.GetILGenerator();
            il.DeclareLocal(typeof(string));
            il.Emit(OpCodes.Ldarg_0);//把参数推到堆栈上
            il.Emit(OpCodes.Stloc_0);//把值保存到索引为0的变量里
            il.Emit(OpCodes.Ldloc_0);//把索引为0的变量推到堆栈上
            call = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            il.Emit(OpCodes.Call, call);//执行Console.WriteLine方法
            il.Emit(OpCodes.Ret);
            test = (Action<string>)dm.CreateDelegate(typeof(Action<string>));
            test("henry");

            //对于下面的方法大家自己推一下,其实很简单.
            //如果看起来有不明白,不防copy到vs.net上然后看指令描述信息:)
            dm = new DynamicMethod("Test2", null,
               new Type[] { typeof(string) }, typeof(string).Module);
            il = dm.GetILGenerator();
            il.DeclareLocal(typeof(string));
            il.Emit(OpCodes.Ldstr, "你好 ");
            il.Emit(OpCodes.Ldarg_0);
            call = typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
            il.Emit(OpCodes.Call, call);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            call = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            il.Emit(OpCodes.Call, call);
            il.Emit(OpCodes.Ret);
            test = (Action<string>)dm.CreateDelegate(typeof(Action<string>));
            test("henry");
            Console.Read();

        }

    }

    // Declare a delegate type that can be used to execute the completed
    // dynamic method. 
    internal delegate int HelloDelegate(string msg, int ret);
}
