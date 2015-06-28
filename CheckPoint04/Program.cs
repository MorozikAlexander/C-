using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint04
{   

    class Program
    {
        static void Main(string[] args)
        {
            DataCollectorUnit DC = new DataCollectorUnit(@"D:\Data");
            Console.ReadKey();
        }
    }
}
