using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{

    class Program
    {


        static void Main(string[] args)
        {

            TransportCompany BelAvia = new TransportCompany("BelaAvia");
            BelAvia.Add(new BaggageUnit() { ID = 1, Name = "Baggage 1", Volume = 0.25, Weight = 15 });
            BelAvia.Add(new AircraftUnit() { ID = 100001, Name = "Boeing 777" });

            BelAvia.Add(new DriverUnit() { ID = 101, Name = "John", LastName = "Smith", CarDriveLicense = true, VolumeCapacity = 1, TrainDriveLicense = true, });

            for (int i = 0; i < BelAvia.Count; i++)


                if (BelAvia[i] is DriverUnit)
                    Console.WriteLine("{0} {1} {2} {3} {4}", BelAvia[i].GetType(), BelAvia[i].ID, BelAvia[i].Name, (BelAvia[i] as DriverUnit).LastName, ((DriverUnit)BelAvia[i]).CarDriveLicense);
                else
                    Console.WriteLine("{0} {1}", BelAvia[i].ID, BelAvia[i].Name);


            
            

            
            Console.ReadKey();
        }
    }
}
