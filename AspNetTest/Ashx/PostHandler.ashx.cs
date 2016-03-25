using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetTest.Ashx
{    
    public class PostHandler : HandlerBase
    {
        public PostHandler()
        {
            base._httpReuqest = base.Context.Request.Form;
        }

        public void Add()
        {
            int a = Convert.ToInt32(_httpReuqest["a"]);
            int b = Convert.ToInt32(_httpReuqest["b"]);
            PrintSuccessJson((a + b).ToString());
        }
    }
}