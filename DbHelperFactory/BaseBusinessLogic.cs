using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public class BaseBusinessLogic
    {
        public static string GetDbHelperClass(DataBaseType dataBaseType = DataBaseType.SqlServer)
        {
            return null;
        }
    }
}
