using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public interface IhasBaggage : ITransportUnit
    {
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }

        public double CurrentWeightValue { get; set; }
        public double CurrentVolumeValue { get; set; }


        public bool LoadBaggage(BaggageUnit item)
        {
            if ((item.Weight + CurrentWeightValue) > WeightCapacity)
            {
                Console.WriteLine("");
                return false;
            }

        }
    }
}
