using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetTest.Common;

namespace TestProjects.MVC.Controllers
{
    public class CacheController : Controller
    {
        public ActionResult Index()
        {
            CacheHelper.SetCache("SMSCode", "4175");
            if (CacheHelper.GetCache("SMSCode") != null)
                ViewBag.CacheValue = CacheHelper.GetCache("SMSCode");
            return View();
        }

        public ActionResult Register()
        {
            if (CacheHelper.GetCache("SMSCode") != null)
            {
                return Json(new { code = 0, msg = "注册成功，验证码：" + CacheHelper.GetCache("SMSCode") }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = 1001, msg = "注册失败" }, JsonRequestBehavior.AllowGet);
        }

    }
}
