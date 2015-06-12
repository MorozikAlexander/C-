using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint03
{
    public class ContractUnit
    {
        public int ContractID;
        public ClientUnit Client;
        public BillingPlanUnit BillingPlan;
        
        public DateTime LastBillingPlanChange;

        public ContractUnit(int contractid, ClientUnit client, BillingPlanUnit billingplan, DateTime registrationdate)
        {
            ContractID = contractid;
            Client = client;
            BillingPlan = billingplan;            
            LastBillingPlanChange = registrationdate;
        }
    }
}
