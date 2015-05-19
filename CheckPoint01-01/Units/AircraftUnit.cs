using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class AircraftUnit : TransportUnit, IisTransport, IhasPassenger
    {
        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();
        public DriverUnit Pilot1;
        public DriverUnit Pilot2;
        public int PassengerCapacity { get; set; }
        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double MaxSpeed { get; set; }        
        public double WayRange { get; set; }
        private double _fuelvalue;
        private double _fuelcons;

        public AircraftUnit()
        {
            kindofunit = KindOfUnit.Aircraft;
        }

        public double FuelValue
        {
            get { return _fuelvalue; }
            set
            {
                if ((value > 0) && (FuelCons > 0))
                {
                    WayRange = (value * 100) / FuelCons;                    
                }
                _fuelvalue = value;
            }
        }

        public double FuelCons
        {
            get { return _fuelcons; }
            set
            {
                if ((value > 0) && (FuelValue > 0))
                {
                    WayRange = (FuelValue * 100) / value;
                }
                _fuelcons = value;
            }
        }

        public bool LoadBaggage(BaggageUnit item)
        {
            throw new NotImplementedException();
        }

        public bool LoadDriver(DriverUnit item)
        {
            throw new NotImplementedException();
        }

        public bool LoadPassenger(PassengerUnit item)
        {
            throw new NotImplementedException();
        }
    }
}
