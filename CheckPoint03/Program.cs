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

            Terminal3.Call(out message, 555, new DateTime(2015, 6, 10, 15, 00, 00));
            Console.WriteLine(message);

            Terminal2.Answer(out message, new DateTime(2015, 6, 10, 15, 01, 00));
            Console.WriteLine(message);

            Terminal2.EndCall(out message, new DateTime(2015, 6, 10, 15, 02, 00));
            Console.WriteLine(message);

            Terminal2.Call(out message, 666, new DateTime(2015, 6, 10, 16, 00, 00));
            Console.WriteLine(message);

            Terminal1.Call(out message, 666, new DateTime(2015, 6, 10, 16, 00, 01));
            Console.WriteLine(message);

            Terminal3.Answer(out message, new DateTime(2015, 6, 10, 16, 01, 00));
            Console.WriteLine(message);

            Terminal3.EndCall(out message, new DateTime(2015, 6, 10, 16, 15, 00));
            Console.WriteLine(message);

            Terminal1.Call(out message, 666, new DateTime(2015, 6, 10, 17, 00, 00));
            Console.WriteLine(message);

            Terminal3.Answer(out message, new DateTime(2015, 6, 10, 17, 01, 00));
            Console.WriteLine(message);

            Terminal1.EndCall(out message, new DateTime(2015, 6, 10, 17, 20, 00));
            Console.WriteLine(message);

            Terminal1.Call(out message, 666, new DateTime(2014, 01, 01, 10, 00, 00));
            Terminal3.Answer(out message, new DateTime(2014, 01, 01, 10, 00, 03));
            Terminal1.EndCall(out message, new DateTime(2014, 01, 01, 10, 25, 00));

            Terminal1.Call(out message, 555, new DateTime(2015, 01, 01, 12, 00, 00));
            Terminal2.Answer(out message, new DateTime(2015, 01, 01, 12, 00, 03));
            Terminal1.EndCall(out message, new DateTime(2015, 01, 01, 13, 30, 00));

            Terminal1.Call(out message, 666, new DateTime(2015, 10, 01, 12, 00, 00));
            Terminal3.Answer(out message, new DateTime(2015, 10, 01, 12, 00, 05));
            Terminal1.EndCall(out message, new DateTime(2015, 10, 01, 15, 15, 00));

            Console.WriteLine("#Биллинг по всем абонентам#");

            TimeSpan calllong;
            if (MyATS.Billing.Count > 0)
                foreach (BillingRecordUnit item in MyATS.Billing)
                {
                    calllong = item.EndCall - item.StartCall;                    
                    Console.WriteLine("Звонок {0} к {1}: c {2} по {3} = {4}", item.Terminal.AbonentNumber, item.toTerminal.AbonentNumber, item.StartCall, item.EndCall, Math.Ceiling(calllong.TotalMinutes));
                    Console.WriteLine("Стоимость:{0}", Math.Ceiling(calllong.TotalMinutes) * item.Terminal.Contract.BillingPlan.MinuteCost);
                }

            TerminalUnit currentTerminal = Terminal1;
            Console.WriteLine("#Биллинг по абоненту#:" + currentTerminal.Contract.Client.SurName + ' ' + currentTerminal.Contract.Client.Name + ' ' + currentTerminal.AbonentNumber);
            List<BillingRecordUnit> currentBilling = new List<BillingRecordUnit>();
            currentBilling = (from c in MyATS.Billing where c.Terminal == currentTerminal orderby c.toTerminal.AbonentNumber select c).ToList<BillingRecordUnit>();
            if (currentBilling.Count > 0)
                foreach (BillingRecordUnit item in currentBilling)
                {
                    calllong = item.EndCall - item.StartCall;
                    Console.WriteLine("Звонок к {1}: c {2} по {3} = {4}", item.Terminal.AbonentNumber, item.toTerminal.AbonentNumber, item.StartCall, item.EndCall, Math.Ceiling(calllong.TotalMinutes));
                    Console.WriteLine("Стоимость:{0}", Math.Ceiling(calllong.TotalMinutes) * item.Terminal.Contract.BillingPlan.MinuteCost);
                }
            Console.ReadKey();
        }
    }
}
