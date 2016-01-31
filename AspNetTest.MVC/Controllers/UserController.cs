using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetTest.MVC.Request;
using AspNetTest.Common;
using System.Net;

namespace AspNetTest.MVC.Controllers
{
    public class UserController : Controller
    {
        List<ValidCodeRequest> list = new List<ValidCodeRequest>();

        public ActionResult CreateValidcode()
        {
            //string type = HttpUtility.UrlEncode(Request.Form["type"]);
            //if (string.IsNullOrEmpty(type))
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            //}
            var request = new ValidCodeRequest
            {
                Id = Guid.NewGuid(),
                VCode = new YZMHelper().Text,
                ExpiredTime = DateTime.Now.AddMinutes(5)
            };
            list.Add(request);
            return Json(request);
        }

        public ActionResult Register()
        {
            Guid id = Guid.Parse(WebQueryHelper.GetString("id"));
            string vcode = WebQueryHelper.GetString("code");
            if (string.IsNullOrEmpty(WebQueryHelper.GetString("id")))
                throw new ArgumentNullException("id");
            if (string.IsNullOrEmpty(WebQueryHelper.GetString("code")))
                throw new ArgumentNullException("code");

            var obj = list.Where(l => l.Id == id).FirstOrDefault();
            if (obj.VCode.Equals(vcode))
            {
                if (DateTime.Now.Subtract(obj.ExpiredTime).TotalMinutes <= 5)
                {
                    return Json(new { Status = 0, Msg = "success" });
                }
                else return Json(new { Status = 1001, Msg = "验证码过期" });
            }
            else return Json(new { Status = 1002, Msg = "验证码不正确" });
        }

    }
}
