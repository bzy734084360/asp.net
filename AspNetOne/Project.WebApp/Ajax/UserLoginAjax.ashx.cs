using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// UserLoginAjax 的摘要说明
    /// </summary>
    public class UserLoginAjax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["userName"];
            string userPwd = context.Request["userPwd"];
            UserInfoService userInfoService = new UserInfoService();
            string msg = string.Empty;
            UserInfo userInfo = null;
            if (userInfoService.ValidateUserInfo(userName, userPwd, out msg, out userInfo))
            {
                context.Session["userInfo"] = userInfo;
                context.Response.Write($"ok:{msg}");
            }
            else
            {
                context.Response.Write($"no:{msg}");
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