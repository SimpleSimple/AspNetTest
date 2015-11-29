using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AspNetTest.Utility;

namespace AspNetTest
{
    public partial class GetVCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyCodeImage verifyCode = new VerifyCodeImage();
            verifyCode.BackgroundColor = System.Drawing.Color.LightGray;
            string code = verifyCode.CreateVerifyCode(5);
            verifyCode.CreateImageOnPage(code, 5, HttpContext.Current);
            if (Session["VerifyCode"] == null)
                Session["VerifyCode"] = code;
            else
            {
                Session.RemoveAll();
                Session["VerifyCode"] = code;
            }
        }
    }
}