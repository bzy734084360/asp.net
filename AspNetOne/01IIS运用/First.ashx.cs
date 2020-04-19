using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// First 的摘要说明
    /// </summary>
    public class First : IHttpHandler
    {

        /// <summary>
        /// 程序员编写的代码
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";//向浏览器返回结果的数据类型
            context.Response.Write("Hello World");//输出服务器处理的结果
            //context.Response.ContentType = "text/html";//向浏览器返回结果的数据类型
            //context.Response.Write("<!DOCTYPE html> " +
            //    "<head>" +
            //    "</head>" +
            //    "<body>" +
            //    "  <p>这是P标签</>" +
            //    "</body>");//输出服务器处理的结果
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