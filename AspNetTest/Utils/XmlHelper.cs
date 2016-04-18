using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace AspNetTest.Utils
{
    public class PostHelp
    {
        public string GetWebContent(string url, string postData = null)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            // 要注意的这是这个编码方式，还有内容的Xml内容的编码方式
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] data = encoding.GetBytes(url);

            // 准备请求,设置参数
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "text/xml";
            //request.ContentLength = data.Length;

            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Flush();
            outstream.Close();
            //发送请求并获取相应回应数据

            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            instream = response.GetResponseStream();

            sr = new StreamReader(instream, encoding);
            //返回结果网页(html)代码

            string content = sr.ReadToEnd();
            return content;
        }
        public string PostXml(string url, string strPost)
        {
            string result = "";

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            //objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "text/xml";//提交xml 
            //objRequest.ContentType = "application/x-www-form-urlencoded";//提交表单
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }
    }

    public class XMLHelp
    {
        private XDocument _document;

        public XDocument Document
        {
            get { return _document; }
            set { _document = value; }
        }
        private string _fPath = "";

        public string FPath
        {
            get { return _fPath; }
            set { _fPath = value; }
        }

        /// <summary>
        /// 初始化数据文件，当数据文件不存在时则创建。
        /// </summary>
        public void Initialize()
        {
            if (!File.Exists(this._fPath))
            {
                this._document = new XDocument(
                new XElement("entity", string.Empty)
                );
                this._document.Save(this._fPath);
            }
            else
                this._document = XDocument.Load(this._fPath);
        }


        public void Initialize(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            this._document = XmlDocumentExtensions.ToXDocument(doc, LoadOptions.None);
        }
        /// <summary>
        /// 清空用户信息
        /// </summary>
        public void ClearGuest()
        {
            XElement root = this._document.Root;
            if (root.HasElements)
            {
                XElement entity = root.Element("entity");
                entity.RemoveAll();
            }
            else
                root.Add(new XElement("entity", string.Empty));
        }

        ///LYJ 修改
        /// <summary>
        /// 提交并最终保存数据到文件。
        /// </summary>
        public void Commit()
        {
            try
            {
                this._document.Save(this._fPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

    public static class XmlDocumentExtensions
    {
        public static XDocument ToXDocument(this XmlDocument document)
        {
            return document.ToXDocument(LoadOptions.None);
        }

        public static XDocument ToXDocument(this XmlDocument document, LoadOptions options)
        {
            using (XmlNodeReader reader = new XmlNodeReader(document))
            {
                return XDocument.Load(reader, options);
            }
        }
    }

    public class XMLSendHelper
    {
        
    }
}