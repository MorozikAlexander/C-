using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_01
{

    class Program
    {


        static void Main(string[] args)
        {
            List<TransportUnit> BelAvia = new List<TransportUnit>();

            
            BelAvia.Add(new AircraftUnit() {ID = 100001, Name = "Boeing 777" });

            BelAvia.Add(new DriverUnit() {VolumeCapacity =1, TrainDriveLicense = true });
            Console.ReadKey();
        }
    }
}
