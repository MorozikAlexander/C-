using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class PassengerUnit : ManUnit , IhasBaggage
    {
        

        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        List<BaggageUnit> Baggage = new List<BaggageUnit>();
    }
}
