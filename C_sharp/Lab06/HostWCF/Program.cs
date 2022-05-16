using InfoPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ContractWCFLibrary;
using CallbackService;

namespace HostWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            MyData.Info();

            Uri baseAddress = new Uri("http://localhost:10004/Complex");
            ServiceHost myHost = new ServiceHost(typeof(MyComplexCalc), baseAddress);
            BasicHttpBinding myBinding = new BasicHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(typeof(ICCalculator), myBinding, "endpoint1");

            Uri baseAddress2 = new Uri("http://localhost:10004/Async");
            ServiceHost myHost2 = new ServiceHost(typeof(AsyncService), baseAddress2);
            ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IAsyncService), myBinding, "endpoint2");

            Uri baseAddress3 = new Uri("http://localhost:10004/Super");
            ServiceHost myHost3 = new
            ServiceHost(typeof(MySuperCalc), baseAddress3);
            WSDualHttpBinding myBinding3 = new WSDualHttpBinding();
            ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISuperCalc), myBinding3, "ThirdService");
            

            //WSHttpBinding myBinding2 = new WSHttpBinding();
            //myBinding2.Security.Mode = SecurityMode.None;
            //ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(typeof(ICCalculator), myBinding2, "endpoint2");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);
            myHost2.Description.Behaviors.Add(smb);
            myHost3.Description.Behaviors.Add(smb);

            try
            {
                myHost.Open();
                myHost2.Open();
                myHost3.Open();               
                Console.WriteLine("-->Service started.");
                Console.WriteLine("--> Callback SuperCalc is running.");
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
                myHost2.Close();
                myHost3.Close();
                Console.WriteLine("--> Callback SuperCalc finished");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("-->Exception occurred: {0}", ce.Message);
                myHost.Abort();
                myHost2.Abort();
                myHost3.Abort();
            }
        }
    }
}
