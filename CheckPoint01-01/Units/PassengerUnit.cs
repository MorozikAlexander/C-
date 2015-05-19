using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class PassengerUnit : ManUnit , IhasBaggage
    {
        public List<BaggageUnit> Baggage = new List<BaggageUnit>();        
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }        

        public PassengerUnit()
        {
            Baggage = null;
            WeightCapacity = 50;
            VolumeCapacity = .2;
            kindofunit = KindOfUnit.Passenger;
        }

        public bool LoadBaggage(BaggageUnit item)
        {
            throw new NotImplementedException();
        }
    }
}
