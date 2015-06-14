using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{

    class Program
    {
        static void Main(string[] args)
        {
            ATSUnit MyATS = new ATSUnit();

            BillingPlanUnit BillingPlan1 = new BillingPlanUnit(1, "Эконом план", 500);
            BillingPlanUnit BillingPlan2 = new BillingPlanUnit(2, "Стандарт план", 1000);
            BillingPlanUnit BillingPlan3 = new BillingPlanUnit(3, "Бизнес план", 1500);

            ClientUnit Client1 = new ClientUnit(1, "Vova", "Putin");
            ClientUnit Client2 = new ClientUnit(2, "Dima", "Medvedev");
            ClientUnit Client3 = new ClientUnit(3, "Alex", "Lukashenko");

            ContractUnit Contract1 = new ContractUnit(1, Client1, BillingPlan3, new DateTime(2015, 1, 1));
            ContractUnit Contract2 = new ContractUnit(2, Client2, BillingPlan2, new DateTime(2015, 6, 1));
            ContractUnit Contract3 = new ContractUnit(3, Client3, BillingPlan1, new DateTime(2015, 6, 10));

            string message;

            TerminalUnit Terminal1 = new TerminalUnit(out message, 777, Contract1, MyATS);
            Console.WriteLine(message);
            TerminalUnit Terminal2 = new TerminalUnit(out message, 555, Contract2, MyATS);
            Console.WriteLine(message);
            TerminalUnit Terminal3 = new TerminalUnit(out message, 666, Contract3, MyATS);
            Console.WriteLine(message);
            TerminalUnit Terminal4 = new TerminalUnit(out message, 666, Contract3, MyATS);
            Console.WriteLine(message);

            Terminal1.On();
            Terminal2.On();
            Terminal3.On();
            Terminal4.On();

            foreach (PortUnit item in MyATS.ATS_Ports)
            {
                Console.WriteLine("ATS Port {1}:{0}", item.Terminal.AbonentNumber, item.PortStatus);

            }

            Console.WriteLine("Terminal Port {1}:{0}", Terminal1.AbonentNumber, Terminal1.LinkOnATSPort.PortStatus);
            Console.WriteLine("Terminal Port {1}:{0}", Terminal2.AbonentNumber, Terminal2.LinkOnATSPort.PortStatus);
            Console.WriteLine("Terminal Port {1}:{0}", Terminal3.AbonentNumber, Terminal3.LinkOnATSPort.PortStatus);




            Terminal3.Call(out message, 555, new DateTime(2015, 6, 10, 15, 00, 00));
            Console.WriteLine(message);
            Terminal2.Call(out message, 666, new DateTime(2015, 6, 10, 15, 00, 00));
            Console.WriteLine(message);



            Console.ReadKey();
        }


    }
}
