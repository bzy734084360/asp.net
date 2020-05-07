using Project.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// DeleteUserAjax 的摘要说明
    /// </summary>
    public class DeleteUserAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            UserInfoService userInfoService = new UserInfoService();
            if (userInfoService.DeleteUserInfo(id))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
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