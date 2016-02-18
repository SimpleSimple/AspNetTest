using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethod.Console
{
    using System;

    /// <summary>
    /// 咖啡因饮料抽象类（父类）
    /// </summary>
    public abstract class CaffeineBeverage
    {
        /// <summary>
        /// 定义要实现的 TemplateMethod（模板方法）
        /// </summary>
        public void prepareRecipe()
        {
            boilWater();
            brew(); // 冲泡
            pourInCup();
            addCondiments();
        }

        protected abstract void brew();

        protected abstract void addCondiments();

        void boilWater()
        {
            Console.WriteLine("Boiling water");
        }

        void pourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }
    }
}
