using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cookie
{
    public partial class CookieDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cookie：是客户端状态保持机制(网站数据存在客户端)
            //创建Cookie
            //Response.Cookies["cp1"].Value = "GrumpyFish";
            //创建Cookie并且指定过期时间
            //Response.Cookies["cp2"].Value = "laowang";
            //Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(3);

            //删除Cookie
            //Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);

            //Cookie 跨域问题(域名)
            Response.Cookies["cp3"].Value = "laowang";
            //解决子域缓存 主域不能访问的机制，把子域缓存设置到主域上
            //Response.Cookies["cp2"].Domain = "xxx.com";
            //
            Response.Cookies["cp3"].Path = @"F:\于富\aspNet\asp.net\AspNetOne\Project.WebApp\Cookie\";
            Response.Cookies["cp3"].Expires = DateTime.Now.AddDays(3);

        }
    }
}