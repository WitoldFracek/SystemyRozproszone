using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    //public class Service1 : IService1
    //{
    //    public string GetData(int value)
    //    {
    //        return string.Format("You entered: {0}", value);
    //    }

    //    public CompositeType GetDataUsingDataContract(CompositeType composite)
    //    {
    //        if (composite == null)
    //        {
    //            throw new ArgumentNullException("composite");
    //        }
    //        if (composite.BoolValue)
    //        {
    //            composite.StringValue += "Suffix";
    //        }
    //        return composite;
    //    }
    //}
    public class MyCalculator : ICalculator
    {
        public double Add(double val1, double val2)
        {
            double result = val1 + val2;
            Console.WriteLine("Method: ADD, val1: " + val1 + " val2: " + val2 + " result: " + result);
            return result;
        }
        public double Sub(double val1, double val2)
        {
            double result = val1 - val2;
            Console.WriteLine("Method: SUB, val1: " + val1 + " val2: " + val2 + " result: " + result);
            return result;
        }
        public double Multiply(double val1, double val2)
        {
            double result = val1 * val2;
            Console.WriteLine("Method: MULTIPLY, val1: " + val1 + " val2: " + val2 + " result: " + result);
            return result;
        }
    }
}
