using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class BaggageUnit : TransportUnit, IisBaggage
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        //public int ID { get; set; }
        //public string Name { get; set; }
    }
}
