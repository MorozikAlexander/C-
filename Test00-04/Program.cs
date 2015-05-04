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
                    EndPoint = new Point {X = 0, Y = 0 } },
                Speed = 45 }
                );

            Console.WriteLine(Mytraffic.Count);

            foreach (var i in Mytraffic)
            {
                Console.WriteLine(i.Name);
                
            }

            Console.ReadKey();
        }
    }
}
