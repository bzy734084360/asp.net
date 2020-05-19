using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MvcStudy.Models
{
    public class DemoFilterAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //在Action执行之后执行，输出到输出流中文字
            filterContext.HttpContext.Response.Write(@"<br/> After Action execute \t" + Message);
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //在Action执行前执行
            filterContext.HttpContext.Response.Write(@"<br/> Before Action execute \t" + Message);
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //在Result执行之后
            filterContext.HttpContext.Response.Write(@"<br/> After ViewResult  execute \t" + Message);
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(@"<br/> Before ViewResult execute \t" + Message);
            //在Result执行之前
            base.OnResultExecuting(filterContext);
        }
    }
}