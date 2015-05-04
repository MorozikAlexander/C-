using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Man_Run : Man, ITransport
    {
        public int Speed { get; set; }
        public GPS Tgps { get; set; }
        public int MaxBaggageLoad { get; set; }
        public int MaxPassengerLoad { get; set; }
    }
}
