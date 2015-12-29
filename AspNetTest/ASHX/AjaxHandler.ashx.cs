﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DBUtility;
using ANT.Model;
using Newtonsoft.Json;


namespace AspNetTest.ASHX
{
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
                case "GETONLINES":
                    GetOnlines();
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

        private void GetOnlines()
        {
            string strSql = "select * from online_user";
            var list = MySqlHelper.ExecuteObjects<OnlineUser>(PublicConstant.MySqlDB, strSql, null)
                .Select(x => new
                {
                    id = x.id,
                    user_id = x.user_id,
                    signin_time = x.signin_time.ToString("yyyy-MM-dd HH:mm:ss"),
                    signout_time = x.signout_time.ToString("yyyy-MM-dd HH:mm:ss")
                });
            string strJSON = JsonConvert.SerializeObject(list);
            HttpContext.Current.Response.Write(strJSON);
            HttpContext.Current.Response.End();
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