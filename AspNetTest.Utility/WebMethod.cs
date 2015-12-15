using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetTest.Utility
{
    public class WebMethod
    {
        static System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;

        public static int GetInt(string parameterName, int defaultVal)
        {
            if (request.QueryString[parameterName] == null)
                return defaultVal;

            return defaultVal;
        }
    }
}
