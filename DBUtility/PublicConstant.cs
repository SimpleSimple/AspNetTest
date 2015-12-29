using System;
using System.Configuration;

namespace DBUtility
{
    public class PublicConstant
    {
        public PublicConstant()
        { }

        public static string MySqlDB
        {
            get { return ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString; }
        }
    }
}
