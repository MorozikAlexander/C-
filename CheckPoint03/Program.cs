using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    class Program
    {
        static void Main(string[] args)
        {            
            ATS MyATS = new ATS();
            Terminal MyTerminal = new Terminal(112233, MyATS);
            MyTerminal.Call(555244);
            Console.ReadKey();
        }
    }
}
