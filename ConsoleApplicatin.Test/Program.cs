using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ConsoleApplication.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.WriteLine("1. 获取验证码");
                Console.WriteLine("2. 请求注册用户");
                Console.WriteLine("退出请按 0 或 quit");
                int no = Convert.ToInt32(Console.ReadLine());
                switch (no)
                {
                    case 1:
                        Console.Write(GetWebRequest("http://localhost:29319/user/createvalidcode", "POST", ""));
                        break;
                    case 2:
                        Console.Write("GUID:");
                        string guid = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Code:");
                        string vcode = Console.ReadLine();
                        Console.WriteLine();
                        string postData = string.Format("id={0}&code={1}", guid, vcode);
                        GetWebRequest("http://localhost:29319/user/register", "POST", postData);
                        break;
                    case 0: break;
                    default: break;
                }
            }
        }

        static string GetWebRequest(string url, string method, string postData)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = method;

                Encoding encoding = Encoding.UTF8;
                byte[] buffer = encoding.GetBytes(postData);
                request.ContentLength = buffer.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, encoding);
                string text = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                return text;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
