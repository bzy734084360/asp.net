using Project.MvcStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project.MvcStudy.Controllers
{
    public class UserInfoController : Controller
    {
        StudyEntities db = new StudyEntities();
        // GET: UserInfo
        [DemoFilter]
        public ActionResult Index()
        {

            int pageIndex;
            if (!int.TryParse(Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            //计算总的记录数
            int rcordCount = db.UserInfo.Where(t => true).Count();
            int pageSize = 5;
            //总的页数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)rcordCount / pageSize));
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            //List<UserInfo> userInfoList = db.UserInfo.Where(u => true).ToList();
            var userInfoList = db.UserInfo.Where(u => true).OrderBy(t => t.UserId).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            StringBuilder sb = new StringBuilder();
            foreach (var item in userInfoList)
            {
                sb.Append($"<tr><td>{item.UserId}</td><td>{item.UserName}</td><td>{item.UserPwd}</td><td>{item.RegDate}</td>" +
                    $"<td><a href=\"/UserInfo/ShowDetail?id={item.UserId}\">详情</a></td>" +
                    $"<td><a href=\"/UserInfo/DeleteUser?id={item.UserId}\" class=\"deletes\">删除</a></td></tr>");
            }
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["pageBar"] = PageBar.GetPageBar(pageIndex, pageCount);
            ViewData["userInfoList"] = sb.ToString();
            ViewData["userInfoListC"] = userInfoList;
            //ViewData["userInfoList"] = userInfoList;
            return View();
        }
        /// <summary>
        /// 参数名只能是ID 通过URL传递过来的参数会自动赋值给该方法的此参数，但是该方法的参数名称一定要与路由格则中的定义的参数的名称一致；
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult ShowDetail(int id)
        public ActionResult ShowDetail(int id)
        {
            var userInfo = db.UserInfo.Where(t => t.UserId == id).FirstOrDefault();
            //ViewData["userInfo"] = userInfo;
            ViewData.Model = userInfo;
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(int id)
        {
            UserInfo userInfo = db.UserInfo.Where(u => u.UserId == id).FirstOrDefault();
            if (userInfo != null)
            {
                db.Entry<UserInfo>(userInfo).State = System.Data.Entity.EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("删除失败");
                }
            }
            else
            {
                return Content("要删除的数据不存在");
            }
        }
    }
}