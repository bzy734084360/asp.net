using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.aspx
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断 请求方式
            //必须判断请求到底是get请求还是Post请求.???
            //如果获取了隐藏域的值，表示用户单击了提交按钮，发起post请求.
            //if (!string.IsNullOrEmpty(Request.Form["isPostBack"]))
            //如果该属性的取值为true,那么就是post请求，否则是false那么就是get请求.如果在建好的aspx页面中有一个<from runat="server">那么返回给浏览器的HTML代码中包含一个名称叫__VIEWSTATE的隐藏域。那么单击表单中的提交按钮时，该隐藏域的值会提交到服务端。那么IsPostBack这个属性就是根据__VIEWSTATE隐藏域的来进行判断是get请求还是POST请求。如果能够拿到该隐藏域的值表示post请求否则为get请求.如果前端页面中没有__VIEWSTATE隐藏域那么就不能用IsPostBack属性来判断是get请求还是Post请求.

            if (IsPostBack || Request.HttpMethod == "Post")
            {
                AddInfo();
            }
        }
        private void AddInfo()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = Request.Form["txtName"];
            userInfo.UserPwd = Request.Form["txtPwd"];
            userInfo.RegDate = DateTime.Now;
            UserInfoService UserInfoService = new UserInfoService();
            if (UserInfoService.AddUserInfo(userInfo))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("/Error.html");
            }
        }

    }
}