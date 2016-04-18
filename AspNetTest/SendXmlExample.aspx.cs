using AspNetTest.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace AspNetTest
{
    public partial class SendXmlExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void button5_Click(object sender, System.EventArgs e)
        {
            string WebUrl = "http://testphp.99ducaijing.cn/index.php?s=/Pay/WxNotify";//换成接收方的URL 
            RequestUrl(WebUrl, GetXml());
        }

        public void RequestUrl(string url, string data)//发送方法 
        {
            var request = WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "text/xml";
            request.Headers.Add("charset:utf-8");
            var encoding = Encoding.GetEncoding("utf-8");
            if (data != null)
            {
                byte[] buffer = encoding.GetBytes(data);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
            }
            else
            {
                //request.ContentLength = 0; 
            }
            //using (HttpWebResponse wr = request.GetResponse() as HttpWebResponse) 
            //{ 
            //    using (StreamReader reader = new StreamReader(wr.GetResponseStream(), encoding)) 
            //    { 
            //        return reader.ReadToEnd(); 
            //    } 
            //} 
        }

        public string GetXml()//要发送的XML 
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            strBuilder.Append("<root>");
            strBuilder.Append("<customer_id>123</customer_id>");
            strBuilder.Append("<terminal_code>10444441</terminal_code>");
            strBuilder.Append("<customer_mobile>13464537875</customer_mobile>");
            strBuilder.Append("<customer_name>张三丰</customer_name>");
            strBuilder.Append("<relationship>母子</relationship>");
            strBuilder.Append("<baby_name>张国立</baby_name>");
            strBuilder.Append("<baby_sex>1</baby_sex>");
            strBuilder.Append("<baby_birthday>2012-06-08</baby_birthday>");
            strBuilder.Append("<province>浙江</province>");
            strBuilder.Append("<region>杭州</region>");
            strBuilder.Append("<county>建德</county>");
            strBuilder.Append("<address>西湖区文三路158号</address>");
            strBuilder.Append("<feedback>1</feedback>");
            strBuilder.Append("</root>");
            return strBuilder.ToString();
        }

        //接收XML
        public void GetDataSet(string text)
        {
            try
            {
                Stream inputstream = Request.InputStream;
                byte[] b = new byte[inputstream.Length];
                inputstream.Read(b, 0, (int)inputstream.Length);
                string inputstr = UTF8Encoding.UTF8.GetString(b);
                XmlDocument d = new XmlDocument();
                d.LoadXml(inputstr);
            }
            catch
            {

            }
        } 
    }
}