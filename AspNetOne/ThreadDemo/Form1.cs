using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //比较低级的做法
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            for (int i = 0; i < 600000000; i++)
            {
                a = i;
            }
            MessageBox.Show(a.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(StartCalc);
            //可直接赋值方法；
            //Thread thread = new Thread(StartCalc);
            Thread thread = new Thread(threadStart);
            //优先级（仅仅为建议。操作系统不能保证此线程优先处理）
            //thread.Priority = ThreadPriority.Highest;
            //给线程起名字
            //thread.Name = "Test";
            //终止线程(不到万不得已，不能用)
            //thread.Abort();
            //提前终止线程，可增加变量来控制；
            //bool isStop = false;
            //设置是否为后台线程()
            thread.IsBackground = true;
            //标记为可运行状态；
            thread.Start();
            //阻塞主线程；(设置主线程等待时间)
            thread.Join(1000);

        }

        bool isStop = false;
        private void StartCalc()
        {
            int a = 0;
            for (int i = 0; i < 600000000; i++)
            {
                if (!isStop)
                {
                    a = i;
                }
                else
                {
                    return;
                }
            }
            //MessageBox.Show(a.ToString());
            this.textBox1.Text = a.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(Show);

            Thread thread = new Thread(parameterizedThreadStart);
            thread.IsBackground = true;
            thread.Start(list);
        }
        private void Show(object obj)
        {
            List<int> list = obj as List<int>;
            foreach (int item in list)
            {
                MessageBox.Show(item.ToString());
            }
        }
        /// <summary>
        /// 跨线程访问
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ShowReslut);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ShowReslut()
        {
            int a = 0;
            for (int i = 0; i < 600000000; i++)
            {
                if (!isStop)
                {
                    a = i;
                }
                else
                {
                    return;
                }
            }
            //是否进行跨线程访问
            if (this.textBox1.InvokeRequired)
            {
                //Invoke说明:去找创建TextBox的线程； 由TextBox的这个线程(主线程)赋值
                this.textBox1.Invoke(new Action<TextBox, string>(SetValueTextBox), this.textBox1, a.ToString());
            }
            else
            {
                this.textBox1.Text = a.ToString();
            }
            //MessageBox.Show(a.ToString());

        }
        private void SetValueTextBox(TextBox txt, string value)
        {
            txt.Text = value;
        }
        /// <summary>
        /// 线程同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(AddSum);
            thread1.IsBackground = false;
            thread1.Start();

            Thread thread2 = new Thread(AddSum);
            thread2.IsBackground = false;
            thread2.Start();
        }
        //定义锁对象
        private static readonly object obj = new object();
        private void AddSum()
        {
            lock (obj)
            {
                for (int i = 0; i < 3000; i++)
                {
                    int a = Convert.ToInt32(this.textBox1.Text);
                    a++;
                    this.textBox1.Text = a.ToString();
                }
            }
        }
        /// <summary>
        /// 线程池
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                new Thread(() =>
                {
                    int i2 = 1 + 1;
                }).Start();
            }
            sw.Stop();
            this.textBox1.Text = this.textBox1.Text + "||" + sw.Elapsed.TotalMilliseconds;

            sw.Reset();
            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PoolCallBack), "sss" + i);
            }
            sw.Stop();

            this.textBox1.Text = this.textBox1.Text + "||" + sw.Elapsed.TotalMilliseconds;

        }

        private void PoolCallBack(object state)
        {
            int j = 1 + 1;
        }
    }
}
