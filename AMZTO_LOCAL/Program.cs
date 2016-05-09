using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMZTO_LOCAL
{
    class Program
    {
        static void Main(string[] args)
        {
            FetchDbData FDX = new FetchDbData();
            Console.WriteLine("Start fetching data");
            string x = FDX.FetchAllLinks();
            Console.ReadKey();
        }
    }
}
