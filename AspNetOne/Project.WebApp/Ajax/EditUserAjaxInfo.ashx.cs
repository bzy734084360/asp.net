using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// EditUserAjaxInfo 的摘要说明
    /// </summary>
    public class EditUserAjaxInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfoService userInfoService = new UserInfoService();
            UserInfo userInfo = userInfoService.GetUserInfoModel(Convert.ToInt32(context.Request["txtEditUserId"]));
            userInfo.UserName = context.Request["txtEditUserName"];
            userInfo.UserPwd = context.Request["txtEditUserPwd"];
            if (userInfoService.EditUserInfoMode(userInfo))
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