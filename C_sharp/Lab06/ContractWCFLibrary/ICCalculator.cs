using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ContractWCFLibrary
{

    [ServiceContract]
    public interface ICCalculator
    {
        [OperationContract]
        Complex add(Complex c1, Complex c2);

        [OperationContract]
        Complex sub(Complex c1, Complex c2);
    }

    [DataContract]
    public class Complex
    {
        string description = "Complex number";

        [DataMember]
        public double real;

        [DataMember]
        public double imag;

        [DataMember]
        public string Desc
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Str
        {
            get
            {
                if (imag >= 0)
                {
                    return $"{real} + {imag}i";
                }
                return $"{real} - {Math.Abs(imag)}i";
            }
        }

        public Complex(double r, double i)
        {
            real = r;
            imag = i;
        }
    }


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //[ServiceContract]
    //public interface IService1
    //{
    //    [OperationContract]
    //    string GetData(int value);

    //    [OperationContract]
    //    CompositeType GetDataUsingDataContract(CompositeType composite);

    //    // TODO: Add your service operations here
    //}

    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //// You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ContractWCFLibrary.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
