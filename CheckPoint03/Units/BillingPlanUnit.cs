using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint03
{
    public class BillingPlanUnit
    {
        private int BillingPlanID;
        private string BillingPlanName;
        public int MinuteCost;

        public BillingPlanUnit(int id, string name, int cost)
        {
            BillingPlanID = id;
            BillingPlanName = name;
            MinuteCost = cost;
        }
    }
}
