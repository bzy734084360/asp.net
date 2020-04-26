using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp
{
    /// <summary>
    /// ValidataCode 的摘要说明
    /// </summary>
    public class ValidataCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            CZBK.ItcastProject.Common.ValidateCode validateCode = new CZBK.ItcastProject.Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            validateCode.CreateValidateGraphic(code, context);
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