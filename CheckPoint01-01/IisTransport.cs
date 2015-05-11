using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    interface IisTransport : IhasPassenger
    {
        double MaxSpeed { get; set; }
        double FuelCons { get; set; }
        double FuelValue { get; set; }
        


    }
}
