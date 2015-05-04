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
                ID = 1,
                CurrentLoad = 25 }
                );

            Mytraffic.Add(new Man() {
                ID = 5,
                LastName = "Ivanov",
                FirstName = "Dmitry",
                CurrentLoad = 90 }
                );

            Mytraffic.Add(new Man_Run() {
                ID = 3,
                LastName = "Bolt",
                FirstName = "Usaine",
                MaxPassengerLoad = 0,
                MaxBaggageLoad = 50,
                Speed = 45 }
                );

            Console.ReadKey();
        }
    }
}
