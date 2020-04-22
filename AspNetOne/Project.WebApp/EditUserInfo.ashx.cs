using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp
{
    /// <summary>
    /// EditUserInfo 的摘要说明
    /// </summary>
    public class EditUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收表单数据
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = Convert.ToInt32(context.Request.Form["UserId"]);
            userInfo.UserName = context.Request.Form["txtName"];
            userInfo.UserPwd = context.Request.Form["txtPwd"];
            userInfo.RegDate = DateTime.Now;
            UserInfoService userInfoService = new UserInfoService();
            if (userInfoService.EditUserInfoMode(userInfo))
            {
                context.Response.Redirect("UserInfoList.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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