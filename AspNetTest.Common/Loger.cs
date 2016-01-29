using System;
using System.IO;
using log4net;
using log4net.Config;
using System.Net;
using System.Text;

namespace AspNetTest.Common
{
    public static class Loger
    {
        static Loger()
        {
            var logConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\bin\log4net.Config";
            var fi = new FileInfo(logConfigPath);
            XmlConfigurator.Configure(fi);
            XmlConfigurator.ConfigureAndWatch(fi);
        }

        private static readonly ILog log = LogManager.GetLogger("log");


        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Warn(string message)
        {
            log.Warn(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }

        public static void Error(object message)
        {
            log.Error(message.ToString());
        }

        public static void Error(Exception ex, string message = "")
        {
            if (ex != null && !string.IsNullOrEmpty(message))
            {
                string error = formateLogError(ex);
                log.ErrorFormat("{0}\r\n【附加信息】:{1}", new object[] { error, message });
            }
            else if (ex == null && !string.IsNullOrEmpty(message))
            {
                log.ErrorFormat("【附加信息】:{0}\r\n", new object[] { message });
            }
            else if (ex != null && string.IsNullOrEmpty(message))
            {
                log.Error(formateLogError(ex));
            }
        }

        private static string formateLogError(Exception ex)
        {
            string error = string.Format("【异常类型】：{0}\r\n【异常堆栈】：{1}\r\n【异常信息】：{2}", ex.GetType().Name, ex.StackTrace, ex.Message);
            return error;
        }
    }
}
