using Project.MvcStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MvcStudy.Controllers
{
    public class DefaultController : Controller
    {
        StudyEntities db = new StudyEntities();
        // GET: Default
        public ActionResult Index()
        {
            ViewData.Model = db.UserInfo.Where(t => true);
            return View();
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            ViewData.Model = db.UserInfo.Where(t => t.UserId == id).FirstOrDefault();
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            try
            {
                // TODO: Add insert logic here
                db.UserInfo.Add(userInfo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model = db.UserInfo.Where(t => t.UserId == id).FirstOrDefault();
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserInfo collection)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData.Model = db.UserInfo.Where(t => t.UserId == id).FirstOrDefault();
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserInfo collection)
        {
            try
            {
                // TODO: Add delete logic here
                //为何获取实体失败！
                db.Entry(collection).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }
    }
}
