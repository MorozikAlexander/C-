using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public abstract class Unit : IUnit
    {
        public enum TypeOfUnit { Man, Car };
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
