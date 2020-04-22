using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// UserInfoUpdate 的摘要说明
    /// </summary>
    public class UserInfoUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //接收传递的用户ID
            string loadUserID = context.Request.QueryString["id"];
            string updateUserId = context.Request.Form["userId"];
            int type = int.Parse(context.Request.QueryString["type"]);
            if (!string.IsNullOrEmpty(loadUserID) || !string.IsNullOrEmpty(updateUserId))
            {
                string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                if (type == 1)
                {
                    //加载
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        using (SqlDataAdapter apter = new SqlDataAdapter("select *from userInfo where Userid=@id", conn))
                        {
                            SqlParameter par = new SqlParameter("@id", SqlDbType.Int, 4);
                            par.Value = loadUserID;
                            apter.SelectCommand.Parameters.Add(par);
                            DataTable da = new DataTable();
                            apter.Fill(da);
                            if (da.Rows.Count < 1)
                            {
                                context.Response.Write("没有此用户");
                            }
                            else
                            {
                                string filePath = context.Request.MapPath("UserInfoUpdate.html");
                                string fileContent = File.ReadAllText(filePath);
                                fileContent = fileContent.Replace("$userName", da.Rows[0]["UserName"].ToString()).Replace("$userPwd", da.Rows[0]["UserPwd"].ToString()).Replace("$userID", loadUserID);
                                context.Response.Write(fileContent);
                            }
                        }
                    }
                }
                else
                {
                    //接收修改数据
                    string userName = context.Request.Form["txtName"];
                    string userPwd = context.Request.Form["txtPwd"];
                    //修改
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "update userinfo set UserName=@UserName,UserPwd=@UserPwd where userid=@id";
                            cmd.Parameters.Add(new SqlParameter("@UserName", userName));
                            cmd.Parameters.Add(new SqlParameter("@UserPwd", userPwd));
                            cmd.Parameters.Add(new SqlParameter("@id", updateUserId));
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

            }
            else
            {
                context.Response.Write("参数异常！");
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