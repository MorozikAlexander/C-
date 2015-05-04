using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public interface ICargo : IUnit
    {
        int CurrentLoad { get; set; }
    }
}
