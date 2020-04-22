using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.WebApp
{
    /// <summary>
    /// UserInfoUpdate 的摘要说明
    /// </summary>
    public class UserInfoUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                //调用业务层,根据接收编号查询用户的信息
                UserInfoService userInfoService = new UserInfoService();
                UserInfo userInfo = userInfoService.GetUserInfoModel(id);
                string filePath = context.Request.MapPath("UserInfoUpdate.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$userName", userInfo.UserName).Replace(
                    "$userPwd", userInfo.UserPwd.Trim()).Replace("$userID", userInfo.UserId.ToString());
                context.Response.Write(fileContent);
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