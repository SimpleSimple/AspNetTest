using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetTest.Ashx
{
    public class GetHandler : HandlerBase
    {
        public GetHandler()
        {
            //修改请求为get 方式
            base._httpReuqest = base.Context.Request.QueryString;
        }

        public void Multiply()
        {
            int a = Convert.ToInt32(_httpReuqest["a"]);
            int b = Convert.ToInt32(_httpReuqest["b"]);
            PrintSuccessJson((a * b).ToString());
        }
    }
}