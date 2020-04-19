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
    /// UserInfoDetail 的摘要说明
    /// </summary>
    public class UserInfoDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            //尝试将接收的参数转换成整数。
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlDataAdapter apter = new SqlDataAdapter("select *from userInfo where Userid=@id", conn))
                    {
                        SqlParameter par = new SqlParameter("@id", SqlDbType.Int, 4);
                        par.Value = id;
                        apter.SelectCommand.Parameters.Add(par);
                        DataTable da = new DataTable();
                        apter.Fill(da);
                        if (da.Rows.Count < 1)
                        {
                            context.Response.Write("没有此用户");
                        }
                        else
                        {
                            string filePath = context.Request.MapPath("ShowDetail.html");
                            string fileContent = File.ReadAllText(filePath);
                            fileContent = fileContent.Replace("$name", da.Rows[0]["UserName"].ToString()).Replace("$pdw", da.Rows[0]["UserPwd"].ToString());
                            context.Response.Write(fileContent);
                        }
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