using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class AircraftUnit : TransportUnit , IisTransport
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public double FuelValue { get; set; }


        public DriverUnit Pilot1 { get; set; }
        public DriverUnit Pilot2 { get; set; }

        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();


        public int PassengerCapacity { get; set; }
    }
}
