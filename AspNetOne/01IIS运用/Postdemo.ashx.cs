using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// Postdemo 的摘要说明
    /// </summary>
    public class Postdemo : IHttpHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("PostDemo.html");
            string fileContent = File.ReadAllText(filePath);
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