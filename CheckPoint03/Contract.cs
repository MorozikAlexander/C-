using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint03
{
    public class ContractUnit
    {
        public ClientUnit Client;
        public BillingPlanUnit BillingPlan;
        public TerminalUnit Terminal;
        public DateTime LastBillingPlanChange;

        public ContractUnit(ClientUnit client, BillingPlanUnit billingplan, TerminalUnit terminal)
        {
            Client = client;
            BillingPlan = billingplan;
            Terminal = terminal;
            LastBillingPlanChange = DateTime.Now;
        }
    }
}
