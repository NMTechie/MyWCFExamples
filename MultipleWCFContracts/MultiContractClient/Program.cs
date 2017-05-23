using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultiContractClient.MyServiceReference;

namespace MultiContractClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client proxy1 = new Service1Client();
            IService2 proxy2 = new Service2Client();

            Console.WriteLine(proxy1.GetData(10));
            Console.WriteLine(proxy2.DoWork("Nilesh"));

            Console.ReadLine();
        }
    }
}
