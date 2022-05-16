using ClientWCF.ComplexCalcReference;
using ContractWCFLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");
            CCalculatorClient ccc = new CCalculatorClient("BasicHttpBinding_ICCalculator");

            bool end = false;
            while (!end)
            {
                int index = GetMethod();
                Complex res = new Complex(0, 0);
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
                }
                if (!end)
                {
                    Console.WriteLine($"Result: {complexToString(res)}");
                }
            }

            ccc.Close();
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
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Sub");
            Console.WriteLine("0. Exit");

            bool isCorrect = false;
            int index = 0;
            while (!isCorrect)
            {
                try
                {
                    index = GetInt();
                    if (index < 3 && index >= 0)
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
