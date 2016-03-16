using DBUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjects.MVC.Models;

namespace TestProjects.MVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            string ConnString = ConfigurationManager.ConnectionStrings["SQLCONN"].ToString();
            Response.Write(ConnString);
            string strSql = "SELECT TOP 1000 * FROM [Gift163DB].[dbo].[Statistics]";
            DataSet ds = SqlHelper.ExecuteDataset(ConnString, CommandType.Text, strSql, null);
            var list = new List<Statistics>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ToList<Statistics>();
                return View(list);
            }
            return View();
        }

    }
}
