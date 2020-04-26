using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.WebApp.UpLoading
{
    /// <summary>
    /// FileUpLoad 的摘要说明
    /// </summary>
    public class FileUpLoad : IHttpHandler
    {
        string[] imgExt = { ".jpg", ".png" };
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //string txtName = context.Request.Form["txtName"];
            //context.Response.Write(txtName);
            //获取上传的文件
            HttpPostedFile file = context.Request.Files[0];//context.Request.Files["fileUp"]
            if (file != null)
            {
                //判断文件的类型；
                //获取文件名
                string fileName = Path.GetFileName(file.FileName);
                //获取拓展名
                string fileExt = Path.GetExtension(fileName);
                if (imgExt.Contains(fileExt))
                {
                    //将文件保存到具体的目录下面
                    //存在问题： 
                    //1、文件重名问题
                    //2、将上传的文件存储到不同的文件夹下(网站优化)
                    //
                    //file.SaveAs(context.Request.MapPath("/ImageUp/" + fileName));
                    string path = context.Request.MapPath("/ImageUp/" + fileName);
                    //最后将上传成功的图片路径保存到数据库
                    //给上传成功的图片添加水印
                    //根据上传成功的图片创建一个Image
                    using (Image img = Image.FromStream(file.InputStream))
                    {
                        //1、创建一个画布
                        using (Bitmap map = new Bitmap(img.Width, img.Height))
                        {
                            //2、为画布创建画笔
                            using (Graphics g = Graphics.FromImage(map))
                            {
                                //3、将上传成功的额图片画到画布上
                                g.DrawImage(img, 0, 0, img.Width, img.Height);
                                //4、在画布上写字
                                g.DrawString("学习视频", new Font("黑体", 14.0f, FontStyle.Italic), Brushes.Red, new PointF(img.Width - 74, img.Height - 50));
                                //5、将画布保存成一张图片,并且指定图片的格式
                                string waterImageName = Guid.NewGuid().ToString();
                                map.Save(context.Request.MapPath("/ImageUp/" + fileName + ".jpg"), ImageFormat.Jpeg);
                                context.Response.Write($"<html><body><img src='/ImageUp/{fileName}.jpg'></body></html>");
                            }
                        }
                    }
                }
                else
                {
                    context.Response.Write("文件类型错误");
                }
            }
            else
            {
                context.Response.Write("请选择上传的文件");
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