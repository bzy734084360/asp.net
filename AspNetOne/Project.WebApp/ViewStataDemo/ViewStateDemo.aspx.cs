using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.ViewStataDemo
{
    public partial class ViewStateDemo : System.Web.UI.Page
    {
        public int Count { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int count = 0;
            if (ViewState["count"] != null)
            {
                count = Convert.ToInt32(ViewState["count"]);
                count++;
                Count = count;
            }
            ViewState["count"] = Count;
        }
    }
}