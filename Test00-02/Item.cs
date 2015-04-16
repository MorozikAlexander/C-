using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_02
{
    class Item
    {
        private string name;
        private int cost;
        private int count;

        public string NameValue
        {
            get { return name; }
            set { name = value; }
        }

        public int CostValue
        {
            get { return cost; }
            set { cost = value; }
        }

        public int CountValue
        {
            get { return count; }
            set { count = value; }
        }

        public int GeneralCostValue()
        {
            return cost * count;
        }
    }
}
