using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{    
    public abstract class TransportUnit : ITransportUnit
    {
        public enum KindOfUnit { Baggage, Passenger, Driver, Car, BaggageWagon, PassengerWagon, Locomotive, Train, Aircraft };
        private KindOfUnit _unitkind;
        public int ID { get; set; }
        public string Name { get; set; }
        public KindOfUnit UnitKind
        {
            get { return _unitkind;  }
            set { _unitkind = value; }
        }
    }
}
