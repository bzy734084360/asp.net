using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// SelfAdd 的摘要说明
    /// </summary>
    public class SelfAdd : IHttpHandler
    {
        protected int num = 0;
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/html";
            //string filePath = context.Request.MapPath("SelfAdd.html");
            //string fileContent = File.ReadAllText(filePath);
            //if (context.Request.Form["txtNum"] == "$num")
            //{
            //    num++;
            //    fileContent = fileContent.Replace("$num", num.ToString());
            //}
            //else
            //{
            //    int addNum = Convert.ToInt32(context.Request.Form["txtNum"]);
            //    addNum++;
            //    fileContent = fileContent.Replace("$num", addNum.ToString());
            //}
            //context.Response.Write(fileContent);
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("SelfAdd.html");
            string fileContent = File.ReadAllText(filePath);
            int num = Convert.ToInt32(context.Request.Form["hiddeNum"]);//接收隐藏域
            num++;
            fileContent = fileContent.Replace("$num", num.ToString());
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