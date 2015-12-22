using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
using System.Configuration;

namespace Console.Tests
{
    class Program
    {
        static string host = ConfigurationManager.AppSettings["redisip"];
        static int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

        static RedisClient client = new RedisClient(host, port);

        static void Main(string[] args)
        {
            //获取所有的key
            var list = client.GetAllKeys();
            list.ForEach(a => System.Console.WriteLine(a.ToString()));

            
        }
    }
}
