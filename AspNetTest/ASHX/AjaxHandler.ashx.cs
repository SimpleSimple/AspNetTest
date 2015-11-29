using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace AspNetTest.ASHX
{
    /// <summary>
    /// AjaxHandler 的摘要说明
    /// </summary>
    public class AjaxHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.Params["type"].ToString();
            switch (act)
            {
                case "CHECKVALIDATECODE":
                    CheckValidateCode();
                    break;
                default: break;
            }
        }

        private void CheckValidateCode()
        {
            string vcode = HttpContext.Current.Request["VCode"] != null ? HttpContext.Current.Request["VCode"] : null;
            if (HttpContext.Current.Session["VerifyCode"] == null)
            {
                HttpContext.Current.Response.Write("{\"Data\":\"failed\",\"State\":\"-1\",\"Msg\":\"验证错误\"}");
                HttpContext.Current.Response.End();
            }
            if (vcode.ToLower() != HttpContext.Current.Session["VerifyCode"].ToString().ToLower())
            {
                HttpContext.Current.Response.Write("{\"Data\":\"suceess\",\"State\":\"-2\",\"Msg\":\"验证错误\"}");
                HttpContext.Current.Response.End();
            }
            if (!string.IsNullOrEmpty(vcode) && vcode.ToLower() == HttpContext.Current.Session["VerifyCode"].ToString().ToLower())
            {
                HttpContext.Current.Response.Write("{\"Data\":\"suceess\",\"State\":\"0\",\"Msg\":\"验证成功\"}");
                HttpContext.Current.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}