using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo
{
    public delegate int AddSum(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //AddSum addSum = new AddSum(p.Add);
            //AddSum addSum = delegate (int a, int b) { return a + b; };
            //AddSum addSum = (int a, int b) => { return a + b; };
            AddSum addSum = (a, b) => { return a + b; };
            int sum = addSum(5, 3);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
