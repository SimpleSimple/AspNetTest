namespace Project.Console.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static readonly int A = B * 10;  // readonly是运行时常量
        static readonly int B = 10;
        public static void Main(string[] args)
        {
            Console.WriteLine("A is {0},B is {1} ", A, B);
        }
    }
}
