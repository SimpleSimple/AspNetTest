using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetTest
{
    public partial class Example03 : System.Web.UI.Page
    {
        protected string matchString = null;
        protected string printStr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string input = "<p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span><span style=\"color:#ff0000;\"></span><span style=\"color:#ff0000;\"></span><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\"></span></p><p><span style=\"color:#ff0000;\">300377 &nbsp;赢 时 胜</span>——定增募资29亿元加码互联网金融</p><p><span style=\"color:#ff0000;\">600499 &nbsp;科达洁能</span>——拟3.79亿元收购安徽科达27.96%股权</p><p><span style=\"color:#ff0000;\">300250 &nbsp;初灵信息</span>——拟募资配套资金不超2.5亿元</p><p><span style=\"color:#ff0000;\">300264 &nbsp;佳创视讯</span>——签订“虚拟现实+广播电视”合作协议</p><p><br /></p><p><span style=\"color:#ff0000;\">❤ ❤ ❤ </span>友情提醒：冲动追高易站岗 从容低吸方位上</p>";
            //string pattern = "<p.*?>(.*?)(?=</p>)";
            string pattern = "<p.*?>(.*?)</p>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(input);
            if (mc.Count > 0)
            {
                foreach (Match match in mc)
                {
                    if (!match.Value.StartsWith("<p><span style=\"color:#ff0000;\"></span>") && !match.Value.Equals("<p><br /></p>"))
                    {
                        matchString += match.Value;
                    }
                }
            }



            DateTime dt = new DateTime();
            dt = DateTime.ParseExact("20160328104521", "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            printStr = dt.ToString();
        }
    }
}