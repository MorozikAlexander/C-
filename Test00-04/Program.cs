using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test00_04_Logistic
{

    
    

    class Program
    {
        static void Main(string[] args)
        {
            Traffic Mytraffic = new Traffic();

            Mytraffic.Add(new Baggage() {
                Name = "HandBag",
                ID = 1,
                CurrentLoad = 25 }
                );

            Mytraffic.Add(new Man() {
                ID = 5,
                LastName = "Ivanov",
                Name = "Dmitry",
                CurrentLoad = 90 }
                );

            Mytraffic.Add(new Man_Run() {
                ID = 3,
                LastName = "Bolt",
                Name = "Usaine",
                MaxPassengerLoad = 0,
                MaxBaggageLoad = 50,                
                Tgps = new GPS() {
                    StartPoint = new Point {X = 0, Y = 0 },
                    EndPoint = new Point {X = 10, Y = 10 } },
                Speed = 45 }
                );

            Mytraffic.Add(new Car_Run() { 
                ID = 6,
                Name = "LADA Kalina",
                MaxPassengerLoad = 5,
                MaxBaggageLoad = 150,
                Tgps = new GPS() {
                    StartPoint = new Point { X = 0, Y = 0 },
                    EndPoint = new Point { X = 50, Y = 50 } },
                Speed = 150 }
                );


            Console.WriteLine(Mytraffic.Count);

            foreach (var i in Mytraffic)
            {
              
                 if (i is ITransport)
                    Console.Write("#Транспорт:");
                 else if (i is ICargo)
                    Console.Write("#Багаж или пассажир:");
                
                Console.WriteLine(i.Name);
                
            }

            Console.ReadKey();
        }
    }
}
