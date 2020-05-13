using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProObject.EFDemo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model2Container db = new Model2Container();
            Customer customer = new Customer() { CustomerName = "张三", CustomerPwd = "123", SubTime = DateTime.Now };
            OrderInfo orderInfo1 = new OrderInfo() { Id = Guid.NewGuid(), OrderNum = "10001", CreateDateTime = DateTime.Now, Customer = customer };
            OrderInfo orderInfo2 = new OrderInfo() { Id = Guid.NewGuid(), OrderNum = "10002", CreateDateTime = DateTime.Now, Customer = customer };
            db.Customer.Add(customer);
            db.OrderInfo.Add(orderInfo1);
            db.OrderInfo.Add(orderInfo2);
            db.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //导航属性应用
            Model2Container db = new Model2Container();
            var customerList = from c in db.Customer
                               select c;
            foreach (var item in customerList)
            {
                //打印名字及他用户下的订单号
                Response.Write(item.CustomerName + ":");
                foreach (var orderInfo in item.OrderInfo)
                {
                    Response.Write(orderInfo.OrderNum);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Model2Container db = new Model2Container();
            //常规方式
            //var customerInfoList = from c in db.Customer
            //                       where c.Id == 1
            //                       select c;
            //var customerInfo = customerInfoList.FirstOrDefault();
            //foreach (var item in customerInfo.OrderInfo)
            //{
            //    Response.Write(customerInfo.CustomerName + ":" + item.OrderNum + "\r\n");
            //}
            //简化方式
            var orderInfoList = from c in db.OrderInfo
                                where c.CustomerId == 1
                                select c;
            foreach (var item in orderInfoList)
            {
                Response.Write(item.OrderNum);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Model2Container db = new Model2Container();
            var orderInfoList = from c in db.OrderInfo
                                where c.OrderNum == "10001"
                                select c;
            var orderInfo = orderInfoList.FirstOrDefault();
            Response.Write(orderInfo.Customer.CustomerName);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Model2Container db = new Model2Container();
            //方式1
            //var customer = (from c in db.Customer
            //                where c.Id == 1
            //                select c).FirstOrDefault();
            //var orderInfoList = customer.OrderInfo;
            ////遍历所有
            //while (orderInfoList.Count > 0)
            //{
            //    var orderInfo = orderInfoList.FirstOrDefault();
            //    db.Entry(orderInfo).State = System.Data.Entity.EntityState.Deleted;
            //}
            //db.SaveChanges();
            var orderList = from o in db.OrderInfo
                            where o.CustomerId == 4
                            select o;
            foreach (var item in orderList)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            }
            db.SaveChanges();

        }
    }
}