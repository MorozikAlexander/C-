using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Man : Unit, ICargo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentLoad { get; set; }

    }
}
