using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    class CarUnit : TransportUnit , IisTransport , IisBaggage, IisMaterialValue
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double MaxSpeed { get; set; }
        public double FuelCons { get; set; }
        public int CostValue { get; set; }
        public double FuelValue { get; set; }
        //public int 
        

        public DriverUnit CarDriver;
        List<BaggageUnit> Baggage = new List<BaggageUnit>();
        List<PassengerUnit> Passengers = new List<PassengerUnit>();




        public int PassengerCapacity { get; set; }


        public double CurrentWeightValue { get; set; }

        public double CurrentVolumeValue { get; set; }

        public bool LoadBaggage(BaggageUnit item)
        {
            return true;
        }






        public bool LoadDriver()
        {
            throw new NotImplementedException();
        }


        public double WayRange
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
