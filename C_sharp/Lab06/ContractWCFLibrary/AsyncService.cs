using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ContractWCFLibrary
{
    public class AsyncService : IAsyncService
    {
        void IAsyncService.Fun1(string s1)
        {
            Console.WriteLine("Called Fun1 - start");
            Thread.Sleep(4 * 1000);
            Console.WriteLine("Fun1 - stop");
        }

        void IAsyncService.Fun2(string s2)
        {
            Console.WriteLine("Called Fun2 - start");
            Thread.Sleep(2 * 1000);
            Console.WriteLine("Fun2 - stop");
        }
    }
}
