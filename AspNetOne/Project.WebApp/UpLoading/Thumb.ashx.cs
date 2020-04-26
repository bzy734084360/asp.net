using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Project.WebApp.UpLoading
{
    /// <summary>
    /// Thumb 的摘要说明
    /// </summary>
    public class Thumb : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("/ImageUp/aa.jpg");
            //创建一个画布，然后让上传的图片画到该画布上，最后保存
            using (Image img = Image.FromFile(filePath))
            {
                using (Bitmap bmp = new Bitmap(50, 50))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
                        string waterImageName = Guid.NewGuid().ToString();
                        bmp.Save(context.Request.MapPath("/ImageUp/" + waterImageName + ".jpg"), ImageFormat.Jpeg);
                        context.Response.Write($"<html><body><img src='/ImageUp/{waterImageName}.jpg'></body></html>");
                    }
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