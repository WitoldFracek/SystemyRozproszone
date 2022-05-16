using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallbackService;


namespace ClientWCF
{
    class SuperCalcCallback : ISuperCalcCallback
    {
        public void FactorialResult(double result)
        {
            //here the result is consumed
            Console.WriteLine(" Factorial = {0}", result);
        }
        public void DoSomethingResult(string info)
        {
            //here the result is consumed
            Console.WriteLine(" Calculations: {0}", info);
        }
    }
}
