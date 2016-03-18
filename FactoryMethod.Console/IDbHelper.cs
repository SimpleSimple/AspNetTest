using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public interface IDbHelper
    {
        string ConnectionString
        { get; set; }
    }
}
