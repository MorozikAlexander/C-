using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public abstract class TransportUnit : ITransportUnit
    {
        public enum KindOfUnit { Baggage, Passenger, Driver, Car, Train, Aircraft };

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
