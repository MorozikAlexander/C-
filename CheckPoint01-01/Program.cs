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
            TransportCompany BelAvia = new TransportCompany("BelaAvia");
            BelAvia.Add(new BaggageUnit() { ID = 10000, Name = "Baggage", Volume = 0.025, Weight = 15 });
            BelAvia.Add(new BaggageUnit() { ID = 10001, Name = "HandBaggage", Volume = 0.05, Weight = 25 });
            BelAvia.Add(new BaggageUnit() { ID = 10002, Name = "RedBox", Volume = 0.1, Weight = 35 });
            BelAvia.Add(new DriverUnit() { ID = 1000, Name = "Medvedev", FirstName = "Dima", CarDriveLicense = true, VolumeCapacity = 0.2, WeightCapacity = 50 });
            BelAvia.Add(new DriverUnit() { ID = 1002, Name = "Putin", FirstName = "Vova", CarDriveLicense = true, VolumeCapacity = 0.2, WeightCapacity = 50, AircraftDriveLicense = true, TrainDriveLicense = true });                                    
            BelAvia.Add(new DriverUnit() { ID = 1001, Name = "Smith", FirstName = "John", CarDriveLicense = true, VolumeCapacity = 1, TrainDriveLicense = true });
            BelAvia.Add(new AircraftUnit() { ID = 1, Name = "AN - 2", FuelCons = 94.5, MaxSpeed = 300, FuelValue = 1500, VolumeCapacity = 5, WeightCapacity = 2500 });
            BelAvia.Add(new AircraftUnit() { ID = 4, Name = "AN - 3", FuelCons = 110, MaxSpeed = 350, FuelValue = 2500, VolumeCapacity = 10, WeightCapacity = 3000 });
            BelAvia.Add(new AircraftUnit() { ID = 3, Name = "AN - 4", FuelCons = 150, MaxSpeed = 450, FuelValue = 3500, VolumeCapacity = 15, WeightCapacity = 3500 });
            BelAvia.Add(new AircraftUnit() { ID = 2, Name = "Boeing", FuelCons = 50, MaxSpeed = 1000, FuelValue = 6000, VolumeCapacity = 35, WeightCapacity = 7000 });
            BelAvia.Add(new CarUnit() { ID = 100, Name = "BMW M5", CostValue = 89900, FuelCons = 17.5, MaxSpeed = 315 });
            BelAvia.Add(new CarUnit() { ID = 101, Name = "BMW M4", CostValue = 59900, FuelCons = 14.5, MaxSpeed = 320 });
            BelAvia.Add(new CarUnit() { ID = 104, Name = "BMW 530", CostValue = 45000, FuelCons = 10.9, MaxSpeed = 250 });
            BelAvia.Add(new CarUnit() { ID = 102, Name = "BMW M1", CostValue = 45900, FuelCons = 10.5, MaxSpeed = 270 });
            BelAvia.Add(new CarUnit() { ID = 103, Name = "LADA Kalina", CostValue = 11000, FuelCons = 8.8, MaxSpeed = 99, PassengerCapacity = 4, VolumeCapacity = 0.8, WeightCapacity = 100 });
                        
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Транспортная <{0}> компания, {1}  элементов по ID:", BelAvia.CompanyName, BelAvia.Count);
            BelAvia.SortByID();
            BelAvia.PrintUnits();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Транспортная <{0}> компания, {1}  элементов по Name:", BelAvia.CompanyName, BelAvia.Count);
            BelAvia.SortByName();
            BelAvia.PrintUnits();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Транспортная <{0}> компания, {1}  элементов по Type:", BelAvia.CompanyName, BelAvia.Count);
            BelAvia.SortByType();
            BelAvia.PrintUnits();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Транспортная <{0}> компания, стоимость машин автопарка:", BelAvia.CompanyName, BelAvia.Count);
            BelAvia.PrintUnitsSortedByCostValue<CarUnit>();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Транспортная <{0}> компания, стоимость автопарка: {1}", BelAvia.CompanyName, BelAvia.CostValue<CarUnit>());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Сортировка автомобилей по расходу топлива:");
            BelAvia.PrintUnitsSortedByFuelCons<CarUnit>();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Сортировка автомобилей по максимальной скорости:");            
            BelAvia.PrintUnitsSortedByMaxSpeed<CarUnit>();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Сортировка автомобилей по максимальной скорости в диапозонах 150-300:");            
            BelAvia.PrintUnitsSortedByMaxSpeedInRange<CarUnit>(150, 300);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Сортировка самолетов по расходу топлива:");
            BelAvia.PrintUnitsSortedByFuelCons<AircraftUnit>();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Общие вместимость:{1} и грузоподемность:{0} самолетов.", BelAvia.WeightCapacity<AircraftUnit>(), BelAvia.VolumeCapacity<AircraftUnit>());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Cамолетов c расходом топлива 80-120 :");
            BelAvia.PrintUnitsSortedByFuelConsInRange<AircraftUnit>(80, 120);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Сортировка самолетов по дальности полета:");
            BelAvia.PrintUnitsSortedByWayRange<AircraftUnit>();

            Console.ReadKey();
        }
    }
}
