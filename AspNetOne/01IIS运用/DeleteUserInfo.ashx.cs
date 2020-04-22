using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// DeleteUserInfo 的摘要说明
    /// </summary>
    public class DeleteUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userId = context.Request.QueryString["id"];
            string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            if (!string.IsNullOrEmpty(userId))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "delete from userinfo where userid=@id";
                        cmd.Parameters.Add("@id", userId);
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
            else
            {
                context.Response.Write("参数异常！！！");
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