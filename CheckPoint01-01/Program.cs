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
            TransportUnit temp1, temp2, temp3, temp4;
            TransportCompany BelAvia = new TransportCompany("BelaAvia");

            temp1 = new BaggageUnit() { ID = 1, Name = "Baggage 1", Volume = 0.025, Weight = 15 };
            temp2 = new BaggageUnit() { ID = 2, Name = "Baggage 2", Volume = 0.05, Weight = 25 };
            temp3 = new BaggageUnit() { ID = 3, Name = "Baggage 3", Volume = 0.1, Weight = 35 };

            temp4 = new DriverUnit() { ID = 100, Name = "Dima", LastName = "Medvedev", CarDriveLicense = true, VolumeCapacity = 0.2, WeightCapacity = 50 };

            

            


            //TransportUnit temp1 = new CarUnit() {CarDriver };


            //BelAvia.Add(new BaggageUnit() { ID = 1, Name = "Baggage 1", Volume = 0.025, Weight = 15 });
            //BelAvia.Add(new BaggageUnit() { ID = 2, Name = "Baggage 2", Volume = 0.025, Weight = 15 });

            BelAvia.Add(new AircraftUnit() { ID = 100001, Name = "Boeing 777" });

            BelAvia.Add(new DriverUnit() { ID = 101, Name = "John", LastName = "Smith", CarDriveLicense = true, VolumeCapacity = 1, TrainDriveLicense = true, });

            Console.WriteLine(BelAvia.Count);

            for (int i = 0; i < BelAvia.Count; i++)


                if (BelAvia[i] is DriverUnit)
                    Console.WriteLine("{0} {1} {2} {3} {4}", BelAvia[i].GetType(), BelAvia[i].ID, BelAvia[i].Name, (BelAvia[i] as DriverUnit).LastName, ((DriverUnit)BelAvia[i]).CarDriveLicense);
                else
                    Console.WriteLine("{0} {1}", BelAvia[i].ID, BelAvia[i].Name);


            
            

            
            Console.ReadKey();
        }
    }
}
