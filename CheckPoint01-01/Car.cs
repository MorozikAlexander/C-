using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_01
{
    class CarUnit : TransportUnit , IisTransport , IisBaggage
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public double FuelValue { get; set; }

        public DriverUnit CarDriver;
        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();




        public int PassengerCapacity { get; set; }
    }
}
