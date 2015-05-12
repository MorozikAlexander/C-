using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public interface IisBaggage : ITransportUnit
    {
        public double Weight { get; set; }
        public double Volume { get; set; }

    }
}
