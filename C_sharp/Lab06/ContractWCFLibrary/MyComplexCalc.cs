using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ContractWCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyComplexCalc : ICCalculator
    {
        Complex ICCalculator.add(Complex c1, Complex c2)
        {
            Console.WriteLine("Called add");
            return new Complex(c1.real + c2.real, c1.imag + c2.imag);
        }

        Complex ICCalculator.sub(Complex c1, Complex c2)
        {
            Console.WriteLine("Called sub");
            return new Complex(c1.real - c2.real, c1.imag - c2.imag);
        }

        Complex ICCalculator.mul(Complex c1, Complex c2)
        {
            Console.WriteLine("Called mul");
            return new Complex(c1.real * c2.real - c1.imag * c2.imag, c1.real * c2.imag + c1.imag * c2.real);
        }
    }
}
