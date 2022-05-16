using ClientWCF.ComplexCalcReference;
using ClientWCF.AsyncServiceReference;
using ContractWCFLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;
using CallbackService;

namespace ClientWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");
            CCalculatorClient ccc = new CCalculatorClient("BasicHttpBinding_ICCalculator");
            AsyncServiceClient asc = new AsyncServiceClient("BasicHttpBinding_IAsyncService");
            bool end = false;
            while (!end)
            {
                int index = GetMethod();
                Complex res = null;
                double r1 = 0.0;
                double r2 = 0.0;
                double i1 = 0.0;
                double i2 = 0.0;
                switch (index)
                {
                    case 0:
                        end = true;
                        Console.WriteLine("Closing");
                        break;
                    case 1:
                        Console.WriteLine("Complex number 1");
                        r1 = GetDouble();
                        i1 = GetDouble();
                        Console.WriteLine("Complex number 2");
                        r2 = GetDouble();
                        i2 = GetDouble();
                        res = ccc.add(new Complex(r1, i1), new Complex(r2, i2));
                        break;
                    case 2:
                        Console.WriteLine("Complex number 1");
                        r1 = GetDouble();
                        i1 = GetDouble();
                        Console.WriteLine("Complex number 2");
                        r2 = GetDouble();
                        i2 = GetDouble();
                        res = ccc.sub(new Complex(r1, i1), new Complex(r2, i2));
                        break;
                    case 3:
                        Console.WriteLine("Async Fun1 (4s)");
                        asc.Fun1("Client 2 message");
                        break;
                    case 4:
                        Console.WriteLine("Async Fun2 (2s)");
                        asc.Fun2("Client 2 message");
                        break;
                }
                if (!end && res != null)
                {
                    Console.WriteLine($"Result: {complexToString(res)}");
                }
            }

            ccc.Close();

            Console.WriteLine("CLIENT2 – START (Async service)");
            AsyncServiceClient client2 = new
            AsyncServiceClient("BasicHttpBinding_IAsyncService");
            Console.WriteLine("...calling Fun 1");
            client2.Fun1("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...continue after Fun 1 call");
            Console.WriteLine("...calling Fun 2");
            client2.Fun2("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...continue after Fun 2 call");
            Console.WriteLine("--> Press ENTER to continue");
            Console.ReadLine();
            client2.Close();
            Console.WriteLine("CLIENT2 - STOP");


            Console.WriteLine("\nCLIENT3 – START (Callbacks):");
            SuperCalcCallback myCbBHandler = new SuperCalcCallback();
            InstanceContext instanceContext = new
            InstanceContext(myCbBHandler);
            SuperCalcClient client3 = new
            SuperCalcClient(instanceContext);
            double value1 = 10;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);
            int value2 = 5;
            Console.WriteLine("...call of DoSomething...");
            client3.DoSomething(value2);
            value1 = 20;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);
            Console.WriteLine("--> Client must wait for the results");
            Console.WriteLine("--> Press ENTER after receiving ALL
            results");
            Console.ReadLine();
            client3.Close();
            Console.WriteLine("CLIENT3 - STOP");
        }

        public static string complexToString(Complex c)
        {
            if (c.imag >= 0)
            {
                return $"{c.real} + {c.imag}i";
            }
            return $"{c.real} - {Math.Abs(c.imag)}i";
        }

        public static int GetMethod()
        {
            Console.WriteLine("\nChoose method:");
            Console.WriteLine("1. Complex Add");
            Console.WriteLine("2. Complex Sub");
            Console.WriteLine("3. Async Fun1 (4s)");
            Console.WriteLine("4. Async Fun2 (2s)");
            Console.WriteLine("0. Exit");

            bool isCorrect = false;
            int index = 0;
            while (!isCorrect)
            {
                try
                {
                    index = GetInt();
                    if (index < 5 && index >= 0)
                    {
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid index");
                }
            }
            return index;
        }

        public static int GetInt()
        {
            bool isCorrect = false;
            int index = 0;
            while (!isCorrect)
            {
                try
                {
                    index = int.Parse(Console.ReadLine().Trim());
                    isCorrect = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid int");
                }
            }
            return index;
        }

        public static double GetDouble()
        {
            bool isCorrect = false;
            double n1 = 0.0;
            while (!isCorrect)
            {
                try
                {
                    n1 = double.Parse(Console.ReadLine().Trim());
                    isCorrect = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data format (maybe use ',' instead of '.')");
                }

            }
            return n1;
        }
    }
}
