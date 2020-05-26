using OA.BLL;
using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        IUserInfoService bll = new UserInfoService();
        public ActionResult Index(UserInfo userInfo)
        {
            //bll.LoadEntities(c => c.ID == 2);
            //bll.AddEntity(userInfo);
            //UserInfoService userInfoService = new UserInfoService();
            //userInfoService.SetUserInfo(userInfo);
            return View();
        }
    }
}