using OA.BLL;
using OA.IBLL;
using OA.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            return View();
        }
        #region 获取用户列表数据

        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            var userInfoList = userInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount, u => u.DelFlag == (short)DeleteEnumType.Normarl, c => c.ID, true);
            var temp = from u in userInfoList
                       select new { u.ID, u.UName, u.UPwd, u.Remark, u.SubTime };

            return Json(new { rows = temp, total = totalCount });
        }

        #endregion

        #region 删除用户数据

        public ActionResult DeleteUserInfo()
        {
            string strID = Request["strId"];
            string[] strIds = strID.Split(',');
            List<int> list = new List<int>();
            foreach (string id in strIds)
            {
                list.Add(Convert.ToInt32(id));
            }
            //将list集合存储的要删除的记录的编号传递到业务层
            if (userInfoService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
            return Json(new { });
        }

        #endregion

    }
}