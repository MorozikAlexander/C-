using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class BaggageWagonUnit : TransportUnit , IhasBaggage
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }

        public BaggageWagonUnit()
        {
            UnitKind = KindOfUnit.BaggageWagon;
        }

        public bool LoadBaggage(BaggageUnit item)
        {
            return true;
        }
    }
}
