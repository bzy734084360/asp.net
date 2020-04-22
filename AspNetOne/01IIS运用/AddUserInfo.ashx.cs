using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// AddUserInfo 的摘要说明
    /// </summary>
    public class AddUserInfo : IHttpHandler
    {
        [Obsolete]
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request.Form["txtName"];
            string userPwd = context.Request.Form["txtPwd"];
            string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into userinfo(UserName,UserPwd,RegDate,TestId)" +
                        "values(@UserName,@UserPwd,@RegDate,@TestId)";
                    cmd.Parameters.Add("@UserName", userName);
                    cmd.Parameters.Add("@UserPwd", userPwd);
                    cmd.Parameters.Add("@RegDate", DateTime.Now);
                    cmd.Parameters.Add("@TestId", 1);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //如果执行成功，跳转到列表页面
                        context.Response.Redirect("UserInfoList.ashx");
                    }
                    else
                    {
                        context.Response.Redirect("Error.html");
                    }
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