using Project.MvcStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Project.MvcStudy.Controllers
{
    public class AjaxDemoController : Controller
    {
        // GET: AjaxDemo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDate()
        {
            return Content(DateTime.Now.ToShortTimeString());
        }
        public ActionResult GetList()
        {
            StudyEntities db = new StudyEntities();
            List<UserInfo> list = db.UserInfo.Where(u => true).ToList();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //return Content(js.Serialize(list));
            return Json(list);
        }

        public ActionResult ShowCreate()
        {
            return View();
        }
        public ActionResult AddUserInfo()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}