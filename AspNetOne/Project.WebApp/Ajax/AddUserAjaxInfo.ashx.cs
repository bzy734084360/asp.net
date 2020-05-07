using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// AddUserAjaxInfo 的摘要说明
    /// </summary>
    public class AddUserAjaxInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = context.Request["txtUserName"];
            userInfo.UserPwd = context.Request["txtUserPwd"]; ;
            userInfo.RegDate = DateTime.Now;
            UserInfoService userInfoService = new UserInfoService();
            if (userInfoService.AddUserInfo(userInfo))
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