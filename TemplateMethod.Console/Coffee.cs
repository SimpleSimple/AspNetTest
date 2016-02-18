using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethod.Console
{
    using System;

    public class Coffee : CaffeineBeverage
    {
        /// <summary>
        /// 冲泡
        /// </summary>
        protected override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        /// <summary>
        /// 添加调料
        /// </summary>
        protected override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }
}
