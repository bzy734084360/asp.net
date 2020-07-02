using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OA.WebApp
{
    /// <summary>
    /// 公共异常处理
    /// </summary>
    public class ErrorCommon
    {
        public static void ErrorSkip(HttpResponse response, int errorCode, HttpServerUtility server)
        {
            string errorPage = string.Empty;
            switch (errorCode)
            {
                case 404:
                    errorPage = "error.html";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(errorPage) && server != null)
            {
                StreamReader stream = new StreamReader(server.MapPath("/") + errorPage);
                //if (!isGlobal)
                //{
                response.StatusCode = errorCode;
                //}
                response.Headers.Add("Content-Type", "text / html; charset = utf - 8");
                response.Write(stream.ReadToEnd());
                response.End();
            }
        }
    }
}