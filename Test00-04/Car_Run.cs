using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Car_Run : Car, ITransport, ICollection<ICargo>
    {
        public int Speed { get; set; }
        public GPS Tgps { get; set; }
        public int MaxBaggageLoad { get; set; }
        public int MaxPassengerLoad { get; set; }

        private ICollection<ICargo> Baggages = new List<ICargo>();
        private ICollection<ICargo> Passengers = new List<ICargo>();



    }
}
