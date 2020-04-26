using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.UpLoading
{
    /// <summary>
    /// DownLoad 的摘要说明
    /// </summary>
    public class DownLoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //国际通用防止产生乱码。生成ASCII
            string encodeFileName = HttpUtility.UrlEncode("webstrom激活码.txt");
            //在响应头中加上Content-Disposition，attachment表示以附件形式下载.
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", encodeFileName));
            //输出文件内容
            context.Response.WriteFile("webstrom激活码.txt");
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