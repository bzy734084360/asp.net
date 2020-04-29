using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cookie
{
    public partial class Cookie2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取Cookie的值
            if (Request.Cookies["cp2"] != null)
            {
                Response.Write(Request.Cookies["cp2"].Value);
            }
        }
    }
}