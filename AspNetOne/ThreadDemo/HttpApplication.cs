using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
    /// <summary>
    /// 完成客户端发送过来的数据的处理
    /// </summary>
    public class HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpApplication()
        {

        }
        Socket socket = null;
        DGShowMSG dGShowMSG = null;
        /// <summary>
        /// 
        /// </summary>
        public HttpApplication(Socket socket, DGShowMSG dGShowMSG)
        {
            this.socket = socket;
            this.dGShowMSG = dGShowMSG;
            //接收客户端发送过来的数据
            byte[] buffer = new byte[1024 * 1024 * 2];
            //接收发送过来的数据，返回的是实际接收的数据的长度；
            int receiveLength = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            if (receiveLength > 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, receiveLength);
                HttpRequest request = new HttpRequest(msg);
                //requset.FilePath;
                ProcessRequest(request);
                dGShowMSG(msg);
            }

        }

        private void ProcessRequest(HttpRequest request)
        {
            string filePath = request.FilePath;
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;//获得当前服务器程序的而运行目录
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Realse"))
            {
                dataDir = Directory.GetParent(dataDir).Parent.Parent.FullName;
            }
            string fullDir = dataDir + filePath;//获取文件完整路径
            using (FileStream fileStream = new FileStream(fullDir, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                //构建相应报文；
                HttpResponse response = new HttpResponse(buffer, filePath);
                socket.Send(response.GetHeaderResponse());//返回响应头
                socket.Send(buffer);
            }
        }
    }
}
