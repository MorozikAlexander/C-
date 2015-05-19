using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    class CarUnit : TransportUnit, IisTransport, IisMaterialValue, IhasPassenger
    {
        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public int CostValue { get; set; }
        public double FuelValue { get; set; }
        public DriverUnit CarDriver;
        public int PassengerCapacity { get; set; }
        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }
        public double WayRange { get; set; }

        public CarUnit()
        {
            UnitKind = KindOfUnit.Car;
        }

        public bool LoadDriver(DriverUnit item)
        {
            if (item != null)
            {
                CarDriver = item;
                return true;
            }
            else return false;
        }

        public bool LoadBaggage(BaggageUnit item)
        {
            return true;
        }

        public bool LoadPassenger(PassengerUnit item)
        {
            return true;
        }
    }
}
