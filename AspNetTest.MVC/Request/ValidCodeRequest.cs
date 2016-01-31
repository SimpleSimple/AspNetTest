using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetTest.MVC.Request
{
    public class ValidCodeRequest
    {
        public ValidCodeRequest() { }

        public Guid Id { get; set; }

        public string VCode { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiredTime { get; set; }
    }
}