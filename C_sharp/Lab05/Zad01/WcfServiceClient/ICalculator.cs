using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceClient
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Sub(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
    }
}
