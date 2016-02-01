using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public abstract class DatabaseFactory
    {
        public static IDatabase CreateInstance(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.SQLServer:
                    return null;
                default: return null;
            }
        }
    }
}
