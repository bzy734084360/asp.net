using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public string FilePath { get; set; }
        public HttpRequest(string msg)
        {
            string[] split = msg.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);//根据请求报文内容进行解析
            FilePath = split[0].Split(' ')[1];//获取请求名称
        }
    }
}
