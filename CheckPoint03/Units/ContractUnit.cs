using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint03
{
    public class ContractUnit
    {
        private int ContractID;
        public ClientUnit Client;
        public BillingPlanUnit BillingPlan;        
        private DateTime LastBillingPlanChange;

        public ContractUnit(int contractid, ClientUnit client, BillingPlanUnit billingplan, DateTime registrationdate)
        {
            ContractID = contractid;
            Client = client;
            BillingPlan = billingplan;            
            LastBillingPlanChange = registrationdate;
        }

        public void BillingPlanChange(out string result, BillingPlanUnit new_billingplan, DateTime new_registrationdate)
        {
            if ((ContractID != 0) && (Client != null))
            {
                if (LastBillingPlanChange != null)
                {
                    BillingPlan = new_billingplan;
                    LastBillingPlanChange = new_registrationdate;
                    result = "Тарифный план успешно изменен!";
                }
                else if ((new TimeSpan(new_registrationdate.Month - LastBillingPlanChange.Month)).TotalDays >= 31)
                {
                    BillingPlan = new_billingplan;                    
                    LastBillingPlanChange = new_registrationdate;                    
                    result = "Тарифный план успешно изменен!";                
                } else result = "Месяц не прошел с последнего изменения тарифного плана!";
            } else result = "Зарегистрируйте контракт вначале!";
        }
    }
}
