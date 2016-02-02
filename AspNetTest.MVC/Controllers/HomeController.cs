using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetTest.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello Message";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);   //清除缓存
            //this.ControllerContext.HttpContext.Response.AddHeader("cache-control", "No-Cache");
            return View();
        }

    }
}
