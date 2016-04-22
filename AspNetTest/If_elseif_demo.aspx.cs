using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetTest
{
    public partial class If_elseif_demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int action = 1;
            string username = "zhizhang";
            if (action == 1)
            {
                if (username == "admin")
                {
                    Response.Write("hello 1");
                }
            }
            else if (action == 2)
            {
                Response.Write("hello 2");
            }
            else
            {
                Response.Write("error");
            }
            /*
             *  if...else if...else 如果条件进入了某一个条件选择器中，最后只会进入符合条件选择器中的区块，而不会在进入else块
             */
        }
    }
}