using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class LocomotiveUnit : PassengerWagonUnit , IisTransport
    {
        public double MaxSpeed { get; set; }

        public double FuelCons { get; set; }

        public double FuelValue { get; set; }













        public bool LoadDriver()
        {
            throw new NotImplementedException();
        }
    }
}
