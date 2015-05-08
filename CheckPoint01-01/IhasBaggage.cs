using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_01
{
    public interface IhasBaggage : ITransportUnit
    {
        double WeightCapacity { get; set; }
        double VolumeCapacity { get; set; }
        
    }
}
