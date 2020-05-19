using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.MvcStudy.Models;

namespace Project.MvcStudy.Controllers
{
    public class HtmlHelperDemoController : Controller
    {
        StudyEntities db = new StudyEntities();
        // GET: HtmlHelperDemo
        public ActionResult Index()
        {

            List<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem { Text = "北京", Value = "1" },
                new SelectListItem{Text="济南",Value="2",Selected=true}
            };
            ViewData["city"] = list;//如果ViewData 的key 的值与DropDownList一直会自动填充下拉框
            var userInfo = db.UserInfo.Where(u => u.UserId == 1039).FirstOrDefault();
            ViewData.Model = userInfo;
            return View();
        }

        public ActionResult CreateUserInfo()
        {
            return View();
        }

        public ActionResult CreateStudentInfo()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult ShowRazior()
        {
            return View();
        }
        public ActionResult ShowLayoutPage()
        {
            return View();
        }
    }
}