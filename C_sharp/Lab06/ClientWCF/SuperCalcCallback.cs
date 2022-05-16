using CallbackService;
using System;

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
