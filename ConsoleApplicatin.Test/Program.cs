using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

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
                Console.WriteLine("3. 请求99dcj网站，进行压力测试");
                Console.WriteLine("退出请按 0 或 quit");
                int no = Convert.ToInt32(Console.ReadLine());
                switch (no)
                {
                    case 0: break;
                    case 1:
                        Console.Write(GetWebRequest("http://localhost:29319/user/createvalidcode", "POST", ""));
                        Console.WriteLine();
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
                        Console.WriteLine();
                        break;
                    case 3:
                        StartWebRequestTask();
                        break;
                    default: break;
                }
            }
        }


        #region Private Static Methods

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

        static void StartWebRequestTask()
        {
            Task task = new Task(() =>
            {
                for (int i = 1; i <= 100000; i++)
                {
                    Console.WriteLine(GetWebRequest("http://www.99ducaijing.com", "POST", ""));
                }
            });
        }
        #endregion
    }
}
