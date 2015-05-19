using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class LocomotiveUnit : TransportUnit, IisTransport 
    {
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public double FuelValue { get; set; }
        public double WayRange { get; set; }

        public LocomotiveUnit()
        {
            kindofunit = KindOfUnit.Locomotive;
        }

        public bool LoadDriver(DriverUnit item)
        {
            throw new NotImplementedException();
        }
    }
}
