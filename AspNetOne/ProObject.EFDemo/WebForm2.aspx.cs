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
        /// <summary>
        /// 新增数据，导航属性关联新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            ModelFirstContainer db = new ModelFirstContainer();
            Customer customer = new Customer() { CustomerName = "张三", CustomerPwd = "123", SubTime = DateTime.Now };
            OrderInfo orderInfo1 = new OrderInfo() { Id = Guid.NewGuid(), OrderNum = "10001", CreateDateTime = DateTime.Now, Customer = customer };
            OrderInfo orderInfo2 = new OrderInfo() { Id = Guid.NewGuid(), OrderNum = "10002", CreateDateTime = DateTime.Now, Customer = customer };
            //先新增客户 否则订单无法拿到用户ID
            db.Customer.Add(customer);
            db.OrderInfo.Add(orderInfo1);
            db.OrderInfo.Add(orderInfo2);
            //默认开启事务
            db.SaveChanges();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            //导航属性应用
            ModelFirstContainer db = new ModelFirstContainer();
            var customerList = from c in db.Customer
                               select c;
            foreach (var item in customerList)
            {
                //打印名字及他用户下的订单号
                Response.Write(item.CustomerName + ":");
                foreach (var orderInfo in item.OrderInfo)//延迟加载
                {
                    Response.Write(orderInfo.OrderNum);
                }
            }
        }
        /// <summary>
        /// 查询某个人的订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            ModelFirstContainer db = new ModelFirstContainer();
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
        /// <summary>
        /// 根据订单查询到用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            ModelFirstContainer db = new ModelFirstContainer();
            var orderInfoList = from c in db.OrderInfo
                                where c.OrderNum == "10001"
                                select c;
            var orderInfo = orderInfoList.FirstOrDefault();
            Response.Write(orderInfo.Customer.CustomerName);
        }
        /// <summary>
        /// 删除某个客户下的所有订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            ModelFirstContainer db = new ModelFirstContainer();
            //方式1 查询用户信息时，获取订单信息，标记订单信息进行删除
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
            //方式2 根据用户外键 标记订单信息
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