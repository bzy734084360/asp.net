using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Request与Response其他成员
{
    public partial class UrlRefer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.Url.ToString());//获取当前请求的url地址
            Response.Write("<hr/>");
            Response.Write(Request.UrlReferrer.ToString());
            //Response.Clear();
            Response.End();
            Response.Write(Request.UserHostAddress.ToString());
            //Server.MapPath()
        }
    }
}