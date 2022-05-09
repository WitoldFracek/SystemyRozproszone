using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient.ServiceReference1;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("... The client has stared");
            Uri baseAddress = new Uri("http://localhost:10004/WcfServiceHost/endpoint1");
            BasicHttpBinding myBiding = new BasicHttpBinding();
            EndpointAddress eAddress = new EndpointAddress(baseAddress);
            ChannelFactory<ICalculator> myCF = new ChannelFactory<ICalculator>(myBiding, eAddress);
            ICalculator myClient = myCF.CreateChannel();
            Console.WriteLine("... calling add");
            double result = myClient.Add(-3.7, 9.5);
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("... press <ENTER> to STOP the client...");
            Console.WriteLine();
            Console.ReadKey();
            ((IClientChannel)myClient).Close();
            Console.WriteLine("... client closed - FINISHED");

            Console.WriteLine("Calculator object 1.");
            CalculatorClient calcClient1 = new CalculatorClient("WSHttpBinding_ICalculator");
            Console.WriteLine("... calling add");
            result = calcClient1.Add(1.0, 3.0);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Summarize:");
            for(int i=0; i<10; i++)
            {
                double sum = calcClient1.Summarize(i);
                Console.WriteLine($"{i}. Sum: {sum}");
            }

            Console.WriteLine("Calculator object 2.");
            CalculatorClient calcClient2 = new CalculatorClient("BasicHttpBinding_ICalculator");
            Console.WriteLine("... calling add");
            result = calcClient2.Add(1.0, 3.0);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Summarize:");
            for (int i = 0; i < 10; i++)
            {
                double sum = calcClient2.Summarize(i);
                Console.WriteLine($"{i}. Sum: {sum}");
            }
            Console.WriteLine("... press <ENTER> to STOP the client...");
            Console.WriteLine();
            Console.ReadKey();
            calcClient1.Close();
            calcClient2.Close();
        }
    }
}
