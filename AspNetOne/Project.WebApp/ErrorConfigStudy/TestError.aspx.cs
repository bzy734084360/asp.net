using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.ErrorConfigStudy
{
    public partial class TestError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = 2;
            int b = 0;
            int c = a / b;
            Response.Write(c);
        }
    }
}