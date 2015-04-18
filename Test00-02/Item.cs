using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_02
{
    public struct ItemStruct
    {
        public string name;
        public int cost;
        public int count;
    }
    
    public class Item
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

        public int SummValue()
        {
            return cost * count;
        }

        public Item(string name, int cost, int count)
        {
            NameValue = name;
            CostValue = cost;
            CountValue = count;
        }

        public Item()
        {
        }
    }
}
