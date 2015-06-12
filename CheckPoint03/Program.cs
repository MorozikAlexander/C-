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

            TerminalUnit Terminal1 = new TerminalUnit(777, Contract1, MyATS);
            TerminalUnit Terminal2 = new TerminalUnit(555, Contract2, MyATS);
            TerminalUnit Terminal3 = new TerminalUnit(666, Contract3, MyATS);


            Console.ReadKey();
        }


    }
}
