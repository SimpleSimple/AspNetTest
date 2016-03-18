using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryMethod.Console
{
    public class DbHelperFactory
    {
        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(string connectionString)
        {
            DataBaseType dataBaseType = DataBaseType.SqlServer;
            return GetHelper(dataBaseType, connectionString);
        }

        /// <summary>
        /// 获取指定的数据库连接
        /// </summary>
        /// <param name="dataBaseType">数据库类型</param>
        /// <param name="connectionString">数据库连接串</param>
        /// <returns>数据库访问类</returns>
        public static IDbHelper GetHelper(DataBaseType dataBaseType = DataBaseType.SqlServer, string connectionString = null)
        {
            // 这里是每次都获取新的数据库连接,否则会有并发访问的问题存在
            string dbHelperClass = BaseBusinessLogic.GetDbHelperClass(dataBaseType);
            IDbHelper dHelper = (IDbHelper)Assembly.Load(BaseSystemInfo.DbHelperAssmely).CreateInstance(dbHelperClass, true);
            if (!string.IsNullOrEmpty(connectionString))
            {
                dHelper.ConnectionString = connectionString;
            }
            return dHelper;
        }
    }
}
