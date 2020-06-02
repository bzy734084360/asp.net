using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.UserInfoServiceClient client = new ServiceReference1.UserInfoServiceClient();
            int sum = client.Add(3, 6);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
