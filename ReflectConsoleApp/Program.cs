using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Activator.CreateInstance("");
            var assembly = System.Reflection.Assembly.LoadFile(Environment.CurrentDirectory + "\\ReflectTestLibrary.dll");

            var type = assembly.GetType("ReflectTestLibrary.SomeMethod");
            //var classInstance = assembly.CreateInstance("ReflectTestLibrary.SomeMethod");

            // 调用静态方法
            MethodInfo methodInfo = type.GetMethod("Add");
            object result = methodInfo.Invoke(null, new object[] { 1, 4 });
            
            Console.WriteLine("反射调用静态方法 Add() 得到的结果:" + result);


        }
    }
}
