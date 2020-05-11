using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Demo
{
    public delegate int SumAdd(int a, int b);
    class Program
    {
        public event SumAdd SumNum;
        static void Main(string[] args)
        {
            //Program p = new Program();
            //指针，指向了方法在内存中的地址； 委托只能指向定义好的签名方法
            //SumAdd sumAdd = new SumAdd(p.AddSum);
            //int sum = sumAdd(6, 3);
            //p.SumNum += p.AddSum;
            //int sum = p.SumNum(6, 3);
            //Console.WriteLine(sum);
            //Console.ReadKey();

            //进程
            //Process[] ps = Process.GetProcesses();
            //foreach (Process item in ps)
            //{
            //    Console.WriteLine(item.ProcessName);
            //    //p.Kill();杀死进程
            //}
            //Process p = Process.GetCurrentProcess();
            //Console.WriteLine(p.ProcessName);
            //Process.Start("notepad.exe");
            Console.ReadKey();
        }
        public int AddSum(int a, int b)
        {
            return a + b;
        }
    }
}
