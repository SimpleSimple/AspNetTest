using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANT.Common
{
    public class Utilities
    {
        /// <summary>
        /// 检测字符串是否是纯数字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static System.Boolean IsNumber(string text)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }

        /// <summary>
        /// 检测输入字符是否为空格
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static System.Boolean IsBlankspace(string text)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\s");
            return regex.IsMatch(text);
        }
    }
}
