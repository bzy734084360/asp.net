using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Project.WebApp.UpLoading
{
    /// <summary>
    /// CreateImage 的摘要说明
    /// </summary>
    public class CreateImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //通过代码来创建一张图片，并且在图片上写字；
            //1、创建画布
            using (Bitmap map = new Bitmap(300, 400))
            {
                //2、为画布创建画笔
                using (Graphics g = Graphics.FromImage(map))
                {
                    //填充画布背景色
                    g.Clear(Color.Aqua);
                    //在画布上写字
                    g.DrawString("学习视频", new Font("黑体", 14.0f, FontStyle.Italic), Brushes.Red, new PointF(150, 200));
                    string fileName = Guid.NewGuid().ToString();
                    //将画布保存成一张图片,并且指定图片的格式
                    map.Save(context.Request.MapPath("/ImageUp/" + fileName + ".jpg"), ImageFormat.Jpeg);
                    context.Response.Write($"<html><body><img src='/ImageUp/{fileName}.jpg'></body></html>");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}