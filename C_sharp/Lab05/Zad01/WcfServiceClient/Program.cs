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
            Console.WriteLine("Starting client");
            CalculatorClient client = new CalculatorClient("WSHttpBinding_ICalculator");
            bool end = false;
            while (!end)
            {
                int index = GetMethod();
                double res = 0.0;
                double n1 = 0.0;
                double n2 = 0.0;
                switch (index)
                {
                    case 1:
                        n1 = GetDouble();
                        n2 = GetDouble();
                        res = client.Add(n1, n2);
                        break;
                    case 2:
                        n1 = GetDouble();
                        n2 = GetDouble();
                        res = client.Sub(n1, n2);
                        break;
                    case 3:
                        n1 = GetDouble();
                        n2 = GetDouble();
                        res = client.Multiply(n1, n2);
                        break;
                    case 4:
                        n1 = GetDouble();
                        n2 = GetDouble();
                        res = client.Divide(n1, n2);
                        break;
                    case 5:
                        n1 = GetDouble();
                        res = client.Summarize(n1);
                        break;
                    case 6:
                        end = true;
                        Console.WriteLine("Closing");
                        break;
                }
                if (!end)
                {
                    Console.WriteLine($"Result: {res}");
                }
            }

            client.Close();
        }

        public static int GetMethod()
        {
            Console.WriteLine("\nChoose method:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Sub");
            Console.WriteLine("3. Mul");
            Console.WriteLine("4. Div");
            Console.WriteLine("5. Summarize");
            Console.WriteLine("6. Exit");
            bool isCorrect = false;
            int index = 0;
            while(!isCorrect)
            {
                try
                {
                    index = GetInt();
                    if(index < 7 && index > 0)
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
            Console.WriteLine("Int");
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
            Console.WriteLine("Real number");
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
