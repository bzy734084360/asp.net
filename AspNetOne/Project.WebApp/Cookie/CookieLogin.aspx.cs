using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cookie
{
    public partial class CookieLogin : System.Web.UI.Page
    {
        public string LoginUserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //在用户登录后添加登录Cookie
            if (Request.HttpMethod == "POST")
            {
                string userName = Request.Form["txtName"].ToString();
                Response.Cookies["userName"].Value = userName;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(3);
                //Response.Redirect("sss");
            }
            else
            {
                //Get访问 读取Cookie
                if (Request.Cookies["userName"] != null)
                {
                    string name = Request.Cookies["userName"].Value;
                    LoginUserName = name;
                }
            }

        }
    }
}