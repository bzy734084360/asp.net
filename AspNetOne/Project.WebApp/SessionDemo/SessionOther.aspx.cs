using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.SessionDemo
{
    public partial class SessionOther : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["str"] = "testSession";
            Response.Redirect("ReadSessionOther.aspx");
        }
    }
}