using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace TestProjects.MVC.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            AspNetTest.Common.Loger.Info("输出日志 success");
            return View();
        }
    }
}
