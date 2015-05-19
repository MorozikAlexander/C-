using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public interface IhasBaggage : ITransportUnit
    {
        double WeightCapacity { get; set; }
        double VolumeCapacity { get; set; }
        double CurrentWeightValue { get; set; }
        double CurrentVolumeValue { get; set; }

        bool LoadBaggage(BaggageUnit item);
    }
}
