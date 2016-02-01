using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public interface IDatabase
    {
        void CreateIntance();
    }

    public enum DbType
    {
        SQLServer, MySQL
    }
}
