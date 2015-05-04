using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public interface ITransport : IUnit
    {
        int Speed { get; set; }
        GPS Tgps { get; set; }
        int MaxBaggageLoad { get; set; }
        int MaxPassengerLoad { get; set; }


    }
}
