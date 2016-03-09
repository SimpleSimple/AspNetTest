using AspNetTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace TestProjects.MVC.Controllers
{
    public class SMSController : Controller
    {
        private const string SMS_REQUEST_WEBSITE = "https://61.145.229.28:8443/httpsgate/sendsubmit?userid=J50929&pwd=256971&phones={0}&pcount=1&subport=*&usrmsgid=&message={1}";
        private const string MESSGAES_CONTENT = "感谢您使用99财经，您此次操作的验证码是：{0}，请尽快校验。您的曾经我们来不及参与，未来我们将会与您紧紧相依！";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPage1()
        {
            return View();
        }
        /// <summary>
        /// 手机短信发送，频繁请求限制功能
        /// </summary>        
        [HttpGet]
        public ActionResult SendVerifyCode()
        {
            try
            {
                string phone = Request["phone"];
                if (String.IsNullOrEmpty(phone))
                    return Json(new { errcode = 1001, errmsg = "手机号不能为空" }, JsonRequestBehavior.AllowGet);

                Random random = new Random();
                string smsCode = random.Next(1000, 9999).ToString();
                if (CacheHelper.GetCache("Sms_" + phone) != null)
                {
                    if (CacheHelper.GetCache("Interval_" + phone) != null)
                    {
                        //CacheHelper.SetCache("Sms_" + phone, null);
                        return Json(new { errcode = 1001, errmsg = "验证码请求过于频繁，请稍后再试" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    CacheHelper.SetCache("Sms_" + phone, smsCode, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
                    CacheHelper.SetCache("Interval_" + phone, smsCode, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration);
                }

                WebRequestHelper.GetHtml(String.Format(SMS_REQUEST_WEBSITE, smsCode, MESSGAES_CONTENT));
                return Json(new { errcode = 1, errmsg = "发送成功" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { errcode = 1110, errmsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
