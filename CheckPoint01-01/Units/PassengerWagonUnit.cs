﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class PassengerWagonUnit : BaggageWagonUnit , IhasPassenger
    {
        public int PassengerCapacity { get; set; }

        public PassengerWagonUnit()
        {
            UnitKind = KindOfUnit.PassengerWagon;
        }

        public bool LoadPassenger(PassengerUnit item)
        {
            return true;
        }
    }
}
