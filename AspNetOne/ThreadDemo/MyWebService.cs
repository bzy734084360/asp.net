using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadDemo
{
    public partial class MyWebService : Form
    {
        public MyWebService()
        {
            InitializeComponent();
        }
        Socket listenSocket = null;
        /// <summary>
        /// 开启服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            //创建了一个负责监听的Socket  IP4设置。 套接字协议。以流的方式，Socket通信协议
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(this.txtIP.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, Convert.ToInt32(this.txtPort.Text));
            //监听的Socket 绑定了一个通信的节点
            listenSocket.Bind(iPEndPoint);
            //设置处于监听状态，以及最大监听数量(同时处理的最大请求)；
            listenSocket.Listen(10);
            //监听请求，若有访问，则立即创建一个Socket通信通道
            //此代码会导致线程阻塞。
            Thread myThread = new Thread(BeginAccpet);
            myThread.IsBackground = true;
            myThread.Start();

        }
        private void BeginAccpet()
        {
            //循环等待监听服务器发送过来的信息，进行创建新的Socket 进行通信；
            while (true)
            {
                Socket newSocket = listenSocket.Accept();
                HttpApplication httpApplication = new HttpApplication(newSocket, ShowMsg);

            }
        }
        private void ShowMsg(string msg)
        {
            if (this.txtContent.InvokeRequired)
            {
                this.txtContent.Invoke(new Action(() => { this.txtContent.AppendText(msg + "\r\n"); }));
            }
            else
            {
                this.txtContent.AppendText(msg + "\r\n");
            }
        }
    }
}
