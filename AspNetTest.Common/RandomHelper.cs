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
                result += random.Next(0, 9);
            }
            return result;
        }

        public List<int> GenerateNumber(int Length)
        {
            //用于保存返回的结果     
            List<int> result = new List<int>(Length);
            Random random = new Random();
            int temp = 0;
            //如果返回的结果集合中实际的元素个数小于6个     
            while (result.Count < Length)
            {
                //在[1,9)区间任意取一个随机整数     
                temp = random.Next(0, 9);
                if (!result.Contains(temp))
                {
                    //如果在结果集合中不存在这个数，则添加这个数     
                    result.Add(temp);
                }
            }
            //result.Sort();//对返回结果进行排序     
            return result;
        }
        #endregion
    }
}
