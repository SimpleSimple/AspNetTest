using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspNetTest.Common;

namespace Samples.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Random_Generator_Test()
        {
            RandomHelper random = new RandomHelper();
            for (int i = 1; i <= 100000; i++)
            {
                //Loger.Info(random.Number(4, false));
            }
        }
    }
}
