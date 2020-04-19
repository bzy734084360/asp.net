using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter apter = new SqlDataAdapter("select *from userInfo", conn))
                {
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        sb.Append($"<tr><td>{da.Rows[i]["UserId"].ToString()}</td><td>{da.Rows[i]["UserName"].ToString()}</td><td>" +
                            $"{da.Rows[i]["UserPwd"].ToString()}</td><td>{Convert.ToDateTime(da.Rows[i]["RegDate"]).ToString("yyyy-MM-dd")}</td>" +
                            $"<td><a href='UserInfoDetail.ashx?id={da.Rows[i]["UserId"].ToString()}'>详细</a></td></tr>");
                    }
                    string filePath = context.Request.MapPath("UserInfoList.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$tbody", sb.ToString());
                    context.Response.Write(fileContent);
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