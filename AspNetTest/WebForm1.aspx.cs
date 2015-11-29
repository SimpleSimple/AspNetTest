using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request["act"] != null ? Request["act"].ToString() : "";
            if (act == "login")
            {
                string userName = Request["UserName"] != null ? Request["UserName"].ToString() : "";
                string code = Request["VCode"] != null ? Request["VCode"].ToString() : "";

                if (string.IsNullOrEmpty(userName))
                {
                    return;
                }

                if (userName == "admin" && code.ToLower() == Session["VerifyCode"].ToString().ToLower())
                {
                    Response.Redirect("WebForm1.aspx?state=SignIn");
                }
                else
                    Response.Redirect("WebForm1.aspx?state=SignOut");
            }
        }
    }
}