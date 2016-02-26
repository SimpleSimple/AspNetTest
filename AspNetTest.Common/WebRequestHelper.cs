using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AspNetTest.Common
{
    /// <summary>
    /// Web请求帮助类
    /// </summary>
    public class WebRequestHelper
    {

        #region 获取网址HTML
        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <returns> </returns>
        public static string GetHtml(string URL)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证 
            HttpWebRequest wrt;
            wrt = WebRequest.Create(URL) as HttpWebRequest;
            wrt.ProtocolVersion = HttpVersion.Version10;  
            wrt.Credentials = CredentialCache.DefaultCredentials;
            WebResponse wrp;
            wrp = wrt.GetResponse();
            string reader = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            try
            {
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                Loger.Error("短信发送失败" + ex.StackTrace + "--" + ex.Message);
            }
            return reader;
        }
        #endregion

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受    
            return true;
        }
    }
}
