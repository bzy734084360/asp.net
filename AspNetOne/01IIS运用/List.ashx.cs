using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// List 的摘要说明
    /// </summary>
    public class List : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            // 从数据库查询到用户信息。替换模板文件中的占位符
            //先找到模板文件
            string filePath = context.Request.MapPath(@"List.html");//获取文件的物理路径、在操作和操作文件夹时，要获取物理路径
            //读取文件内容、并且替换占位符
            string fileContent = File.ReadAllText(filePath).Replace("$username", "张三").Replace("$userpwd", "123456");

            context.Response.Write(fileContent);
            //aspx  另一种处理方式

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