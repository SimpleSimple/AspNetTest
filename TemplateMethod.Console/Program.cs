using System.Collections.Generic;
using System.Linq;

namespace TemplateMethod.Console
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CaffeineBeverage caffeineBeverage;

            caffeineBeverage = new Tea();
            caffeineBeverage.prepareRecipe();
            Console.WriteLine();

            caffeineBeverage = new Coffee();
            caffeineBeverage.prepareRecipe();

            Console.ReadLine();
        }
    }
}
