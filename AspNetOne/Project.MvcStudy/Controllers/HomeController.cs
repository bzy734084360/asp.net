using Project.MvcStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MvcStudy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //约定大于配置。
        public ActionResult Index()
        {
            return View();//找视图的；
        }

        public ActionResult About()
        {
            return View();
        }
        [HttpGet]//只能接收Get 不加的话则都可以，
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]//只能接收Post请求 优先处理POST请求，大于不加特性的方法
        public ActionResult Register(UserInfo userInfo)
        {
            userInfo.RegDate = DateTime.Now;
            StudyEntities db = new StudyEntities();
            db.UserInfo.Add(userInfo);
            if (db.SaveChanges() > 0)
            {
                //return Content("添加成功");
                //return RedirectToAction("Index");//返回当前路由下的Index页面
                //return RedirectToAction("Index", "UserInfo");//跳转到UserInfo控制器下的Index方法
                //return Redirect("/UserInfo/Index");//指定URL
                return Content("ok");//AJAX方法需这样返回
            }
            else
            {
                return Content("no");
            }
            //return View();
        }
        /// <summary>
        /// 如果方法的参数的名称与表单元素的name的属性值一致的话，会自动填充
        /// </summary>
        /// <param name="txtName"></param>
        /// <param name="txtPwd"></param>
        /// <returns></returns>
        //public ActionResult AddUserInfo(string txtName, string txtPwd)
        //{
        //如果表单元素的name属性的值与实体类中属性的名字保持一致，那么表单中的数据会自动赋值给实体中的属性(自动填充机制)
        public ActionResult AddUserInfo(UserInfo userInfo)
        {
            //UserInfo userInfo = new UserInfo();
            //userInfo.UserName = Request["txtName"];
            //userInfo.UserPwd = Request["txtPwd"];
            //userInfo.RegDate = DateTime.Now;
            //userInfo.UserName = txtName;
            //userInfo.UserPwd = txtPwd;
            userInfo.RegDate = DateTime.Now;
            StudyEntities db = new StudyEntities();
            db.UserInfo.Add(userInfo);
            if (db.SaveChanges() > 0)
            {
                //return Content("添加成功");
                //return RedirectToAction("Index");//返回当前路由下的Index页面
                //return RedirectToAction("Index", "UserInfo");//跳转到UserInfo控制器下的Index方法
                //return Redirect("/UserInfo/Index");//指定URL
                return Content("ok");//AJAX方法需这样返回
            }
            else
            {
                return Content("no");
            }
        }
    }
}