using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class AircraftUnit : TransportUnit, IisTransport
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double MaxSpeed { get; set; }        
        public double WayRange { get; set; }

        private double FV;

        public double FuelValue
        {
            get { return FV; }
            set
            {
                if ((value > 0) && (FuelCons > 0))
                {
                    WayRange = (value * 100) / FuelCons;                    
                }
                FV = value;
            }
        }

        private double FC;

        public double FuelCons
        {
            get { return FC; }
            set
            {
                if ((value > 0) && (FuelValue > 0))
                {
                    WayRange = (FuelValue * 100) / value;
                }
                FC = value;
            }
        }

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
