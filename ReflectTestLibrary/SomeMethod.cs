using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectTestLibrary
{
    public abstract class SomeMethod
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }


        public abstract void Sub();

        public abstract void Cheng();

        public abstract void Chu();
    }
}
