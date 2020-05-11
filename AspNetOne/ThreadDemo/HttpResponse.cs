using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponse
    {
        byte[] buffer = null;
        public string Content_Type { get; set; }
        public HttpResponse(byte[] buffer, string filePath)
        {
            this.buffer = buffer;

            string fileExt = Path.GetExtension(filePath);
            switch (fileExt)
            {
                case ".html":
                case ".htm":
                    Content_Type = "text/html";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 构建报文头
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeaderResponse()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("HTTP/1.1 200 ok \r\n");
            builder.Append("Content-Type:" + Content_Type + "\r\n");
            builder.Append("Content-Length:" + buffer.Length + "\r\n");
            
            return Encoding.UTF8.GetBytes(builder.ToString());
        }
    }
}
