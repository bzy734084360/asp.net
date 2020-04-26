using Project.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.aspx
{
    /// <summary>
    /// DeleteUserInfo 的摘要说明
    /// </summary>
    public class DeleteUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request.QueryString["Id"], out id))
            {
                UserInfoService userInfoService = new UserInfoService();
                if (userInfoService.DeleteUserInfo(id))
                {
                    context.Response.Redirect("Index.aspx");
                }
                else
                {
                    context.Response.Redirect("/Error.html");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}