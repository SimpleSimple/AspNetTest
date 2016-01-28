using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace TestProjects.MVC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string pathToRewriteTo = Request.Path.ToLowerInvariant().Replace("default.aspx", "Product/Index");
            //HttpContext.Current.RewritePath(pathToRewriteTo, false);
            //IHttpHandler httpHandler = new MvcHttpHandler();
            //httpHandler.ProcessRequest(HttpContext.Current);
            //HttpContext.Current.Server.TransferRequest(Request.ApplicationPath);

            HttpContext.Current.Server.TransferRequest(
                Request.Path.ToLowerInvariant().Replace("default.aspx", "Product/Index"));
        }
    }
}