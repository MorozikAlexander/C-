﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    interface IisTransport
    {
        double MaxSpeed { get; set; }
        double FuelCons { get; set; }
        double WayRange { get; set; }
        double FuelValue { get; set; }

        bool LoadDriver(DriverUnit item);
    }
}
