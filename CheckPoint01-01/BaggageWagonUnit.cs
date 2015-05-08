using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_01
{
    public class BaggageWagonUnit : TransportUnit , IhasBaggage , IisBaggage
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
    }
}
