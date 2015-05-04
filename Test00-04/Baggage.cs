using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Baggage : Unit, ICargo
    {

        public int CurrentLoad { get; set; }
    }
}
