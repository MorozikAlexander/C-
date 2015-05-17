using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class AircraftUnit : TransportUnit , IisTransportWithTempomat
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public double FuelValue { get; set; }
        public double WayRange  { get; set; }
        public int PassengerCapacity { get; set; }
        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }

        public DriverUnit Pilot1 { get; set; }
        public DriverUnit Pilot2 { get; set; }

        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();

        public bool LoadBaggage(BaggageUnit item)
        {
            throw new NotImplementedException();
        }

        public bool LoadDriver()
        {
            throw new NotImplementedException();
        }
    }
}
