using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetTest.Common
{
    public class RandomHelper
    {
        System.Random random = new Random();
        #region 生成随机数
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="Sleep"></param>
        /// <returns></returns>
        public string Number(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            string result = "";

            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
        #endregion
    }
}
