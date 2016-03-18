using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public class BaseSystemInfo
    {
        public const string DbHelperAssmely = "";

        public const DataBaseType WorkFlowDbType = DataBaseType.SqlServer;
        public const string WorkFlowDbConnection = "";

        public const DataBaseType BusinessDbType = DataBaseType.SqlServer;
        public const string BusinessDbConnection = "";

        public const DataBaseType UserCenterDbType = DataBaseType.SqlServer;
        public const string UserCenterDbConnection = "";
    }
}
