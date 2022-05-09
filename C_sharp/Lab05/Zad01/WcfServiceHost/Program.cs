using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 Create the URI of service base address
            Uri baseAddress = new Uri("http://localhost:10004/WcfServiceHost");
            // Step 2 Create service instance.
            ServiceHost myHost = new ServiceHost(typeof(MyCalculator), baseAddress);
            // Step 3 Add the endpoint.
            BasicHttpBinding myBinding = new BasicHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(ICalculator), myBinding, "endpoint1");

            WSHttpBinding binding2 = new WSHttpBinding();
            binding2.Security.Mode = SecurityMode.None;
            ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(typeof(ICalculator), binding2, "endpoint2");
            // Step 4 Set up metadata and publish service metadata
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);

            // Step 5 Run the service.
            try
            {
                myHost.Open();
                Console.WriteLine("-->Service started.");
                Console.WriteLine("-->Endpoints:");
                Console.WriteLine($"    Service endpoint: {endpoint1.Name}");
                Console.WriteLine($"    Binding: {endpoint1.Binding}");
                Console.WriteLine($"    ListenerUri: {endpoint1.ListenUri}\n");
                Console.WriteLine($"    Service endpoint: {endpoint2.Name}");
                Console.WriteLine($"    Binding: {endpoint2.Binding}");
                Console.WriteLine($"    ListenerUri: {endpoint2.ListenUri}\n");
                Console.WriteLine("-->Press <ENTER> to STOP service...");
                Console.WriteLine();
                Console.ReadLine(); // to not finish app immediately:
                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("-->Exception occurred: {0}", ce.Message);
                myHost.Abort();
            }
        }
    }
}
