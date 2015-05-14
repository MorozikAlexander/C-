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
            /* Recommended ID's ranges:
             * 1     ..    9 : Aircrafts
             * 10    ..   99 : Trains, Locomotives, Passenger & Baggage Wagons
             * 100   ..  999 : Cars
             * 1000  .. 9999 : Mans - Drivers & Passengers
             * 10000 ..      : Baggages
             * 
             * 
             */

            Console.WriteLine(Console.ForegroundColor);
            TransportUnit temp1, temp2, temp3, temp4;
            TransportCompany BelAvia = new TransportCompany("BelaAvia");

            temp1 = new BaggageUnit() { ID = 10000, Name = "Baggage 1", Volume = 0.025, Weight = 15,  };
            temp2 = new BaggageUnit() { ID = 10001, Name = "Baggage 2", Volume = 0.05, Weight = 25 };
            temp3 = new BaggageUnit() { ID = 10002, Name = "Baggage 3", Volume = 0.1, Weight = 35 };

            temp4 = new DriverUnit() { ID = 1000, Name = "Dima", LastName = "Medvedev", CarDriveLicense = true, VolumeCapacity = 0.2, WeightCapacity = 50 };

            BelAvia.Add(temp1);
            BelAvia.Add(temp2);
            BelAvia.Add(temp3);
            BelAvia.Add(temp4);


            BelAvia.Add(new AircraftUnit() { ID = 1, Name = "AN - 2", FuelCons = 94.5, MaxSpeed = 300 });

            BelAvia.Add(new DriverUnit() { ID = 10001, Name = "John", LastName = "Smith", CarDriveLicense = true, VolumeCapacity = 1, TrainDriveLicense = true, });

            BelAvia.Add(new CarUnit() { ID = 100, Name = "BMW M5", CostValue = 89900, FuelCons = 17.5, MaxSpeed = 320 });

            BelAvia.Add(new CarUnit() { ID = 101, Name = "BMW M4", CostValue = 59900, FuelCons = 14.5, MaxSpeed = 300 });

            BelAvia.Add(new CarUnit() { ID = 102, Name = "BMW M1", CostValue = 45900, FuelCons = 10.5, MaxSpeed = 270 });


            Console.WriteLine(BelAvia.Count);

            for (int i = 0; i < BelAvia.Count; i++)


                if (BelAvia[i] is DriverUnit)
                    Console.WriteLine("{0} {1} {2} {3} {4}", BelAvia[i].GetType(), BelAvia[i].ID, BelAvia[i].Name, (BelAvia[i] as DriverUnit).LastName, ((DriverUnit)BelAvia[i]).CarDriveLicense);
                else
                    Console.WriteLine("{0} {1}", BelAvia[i].ID, BelAvia[i].Name);

            BelAvia.SortByID();
            BelAvia.PrintUnits();

            BelAvia.SortByName();
            BelAvia.PrintUnits();

            Console.WriteLine(BelAvia.CostValue<CarUnit>());

            BelAvia.SortByFuelCons<CarUnit>();

            BelAvia.SortByFuelCons<AircraftUnit>();

            BelAvia.SortByFuelCons<IisTransport>();


            Console.ReadKey();
        }
    }
}
