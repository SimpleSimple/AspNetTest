using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethod.Console
{
    using System;

    public class Tea : CaffeineBeverage
    {
        protected override void brew()
        {
            Console.WriteLine("Steeping the tea");
        }

        /// <summary>
        /// 添加调料
        /// </summary>
        protected override void addCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }
}
