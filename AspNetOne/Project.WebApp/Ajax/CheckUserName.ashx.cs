using Project.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// CheckUserName 的摘要说明
    /// </summary>
    public class CheckUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["name"];
            UserInfoService userInfoService = new UserInfoService();
            if (userInfoService.GetUserInfoModel(userName) != null)
            {
                context.Response.Write("此用户名已存在!");
            }
            else
            {
                context.Response.Write("此用户名可用!");
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