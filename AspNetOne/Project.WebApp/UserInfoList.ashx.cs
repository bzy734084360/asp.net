using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Project.WebApp
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            UserInfoService userInfoService = new UserInfoService();
            List<UserInfo> list = userInfoService.GetList();
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo userinfo in list)
            {
                sb.Append($"<tr><td>{userinfo.UserId}</td><td>{userinfo.UserName}</td><td>" +
                $"{userinfo.UserPwd}</td><td>{userinfo.RegDate.ToString("yyyy-MM-dd")}</td>" +
                $"<td><a href='UserInfoDetail.ashx?id={userinfo.UserId}'>详细</a></td>" +
                $"<td><a href='UserInfoUpdate.ashx?id={userinfo.UserId}&type=1'>修改</a></td>" +
                $"<td><a href='DeleteUserInfo.ashx?id={userinfo.UserId}' class='deletes'>删除</a></td></tr>");
            }


            string filePath = context.Request.MapPath("UserInfoListModel.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("$tbody", sb.ToString());
            context.Response.Write(fileContent);
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