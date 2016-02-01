namespace Project.Console.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        private class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static void Main(string[] args)
        {
            Static_ReadOnly_Test();
        }

        #region 检查静态变量和只读变量的区别
        static readonly int A = B * 10;  // readonly是运行时常量
        static readonly int B = 10;

        static void Static_ReadOnly_Test()
        {
            Console.WriteLine("A is {0}，B is {1} ", A, B);
        }
        #endregion

        static void LinqExpression_Where_Test()
        {
            var users = new List<User> { 
                new User{Id=1, Name="Cube"},
                new User{Id=2, Name="Jimmy"}
            };


        }
    }
}
