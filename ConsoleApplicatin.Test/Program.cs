using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ConsoleApplication.Test
{
    using AspNetTest.Common;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0. 退出");
            Console.WriteLine("1. 获取验证码");
            Console.WriteLine("2. 请求注册用户");
            Console.WriteLine("3. 请求99dcj网站，进行压力测试");
            Console.WriteLine("4. 测试缓存接口");

            while (1 == 1)
            {
                Console.WriteLine("请输入执行序号：");
                string readline = Console.ReadLine();
                int no = 0;
                if (string.IsNullOrEmpty(readline))
                    no = -1;
                else no = Int32.Parse(readline);
                switch (no)
                {
                    case 0:
                        goto QUIT;
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
                    case 4:
                        Register_Test();
                        break;
                    default: break;
                }
            }

        QUIT:
            Random_Generator_Test();

            Console.Write("已退出");
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
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

        static void Register_Test()
        {
            try
            {
                Console.Write("输入短信验证码：");
                string smscode = Console.ReadLine().Trim();
                var request = new { phone = "13018413303", code = smscode, pwd = "a123456" };
                string json = JsonConvert.SerializeObject(request);
                string Url = "http://localhost:7359/cache/register";
                Console.WriteLine(GetWebRequest(Url, "POST", json));
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }
        }
        #endregion

        static void Random_Generator_Test()
        {
            RandomHelper random = new RandomHelper();

            for (int i = 1; i <= 100000; i++)
            {
                Loger.Info(random.Number(4, false));

            }

            //for (int i = 1; i <= 100000; i++)
            //{
            //    Loger.Info(String.Join("", random.GenerateNumber(4)));
            //}
            Console.WriteLine("生成结束");
        }
    }
}
