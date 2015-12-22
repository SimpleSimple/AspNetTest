using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANT.Common;

namespace AspNetTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request["act"] != null ? Request["act"].ToString() : "";
            if (act == "login")
            {
                string username = Request["UserName"] != null ? Request["UserName"].ToString() : "";
                string code = Request["VCode"] != null ? Request["VCode"].ToString() : "";
                string userpwd = Request["UserPass"] != null ? Request["UserPass"] : "";

                if (!string.IsNullOrEmpty(username) && username != "admin")
                {
                    //MessageBox.ShowAndRedirect(this.Page, "用户名错误", "WebForm1.aspx");
                    Response.Write("<script language='javascript'>alert('用户名错误');history.go(-1)</script>");
                }

                if (code.ToLower() != Session["VerifyCode"].ToString().ToLower())
                {
                    Response.Write("<script language='javascript'>alert('验证错误');history.go(-1)</script>");
                }

                if (username == "admin" && userpwd == "admin" && code.ToLower() == Session["VerifyCode"].ToString().ToLower())
                {
                    Response.Redirect("WebForm1.aspx?state=SignIn");
                }
                else
                {
                    MessageBox.Show(this.Page, "用户名或密码错误");
                    return;
                }
            }
        }
    }
}