using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using MultipleWCFContracts;

namespace ServiceHostApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(Service1));
                BasicHttpBinding mybinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                //host.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), "http://localhost:8091/HostedService");
                //host.AddServiceEndpoint(typeof(IService2), new BasicHttpBinding(), "http://localhost:8091/HostedService");
                host.AddServiceEndpoint(typeof(IService1), mybinding, "http://localhost:8091/HostedService");
                host.AddServiceEndpoint(typeof(IService2), mybinding, "http://localhost:8091/HostedService");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8091/HostedService");
                host.Description.Behaviors.Add(smb);
                host.Open();
                Console.WriteLine("The Service is Running");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }
            }
            finally
            {
                host.Close();
                Console.ReadLine();
            }
        }
    }
}
