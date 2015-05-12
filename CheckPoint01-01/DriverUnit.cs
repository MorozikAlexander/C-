using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class DriverUnit : PassengerUnit
    {
        public bool CarDriveLicense { get; set; }
        public bool TrainDriveLicense { get; set; }
        public bool AircraftDriveLicense { get; set; }

        public DriverUnit()
        {
            CarDriveLicense = false;
            TrainDriveLicense = false;
            AircraftDriveLicense = false;
            Baggage = null;
            WeightCapacity = 50;
            VolumeCapacity = .2;

        }
    }
}
