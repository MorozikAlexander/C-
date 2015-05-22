using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class TransportCompany
    {
        private List<TransportUnit> TUnits = new List<TransportUnit>();        
        public string CompanyName { get; set; }

        public TransportCompany(string companyname)
        {
            CompanyName = companyname;
        }

        #region TUnits methods
        public TransportUnit this[int index]
        {
            get
            {
                return TUnits[index];
            }
            set
            {
                TUnits[index] = value;                
            }
        }

        public void Add(TransportUnit item)
        {
            TUnits.Add(item);
        }

        public void Clear()
        {
            TUnits.Clear();
        }

        public bool Contains(TransportUnit item)
        {
            return TUnits.Contains(item);
        }

        public int Count
        {
            get { return TUnits.Count; }
        }
        #endregion

        #region Sorting
        protected void Sort(IComparer<TransportUnit> comparer)
        {
            TUnits.Sort(comparer);
        }

        public void SortByType()
        {
            this.Sort(new TransportUnitComparerByType());
        }

        public void SortByID()
        {
            this.Sort(new TransportUnitComparerByID());
        }

        public void SortByName()
        {
            this.Sort(new TransportUnitComparerByName());
        }
        #endregion

        #region Prints
        public void PrintUnitsSortedByFuelCons<T>()
        {
            PrintUnitsSortedByFuelConsInRange<T>(0, 0);
        }

        public void PrintUnitsSortedByFuelConsInRange<T>(double min, double max)
        {
            TUnits.ExtUnitsSelectByType<T>().ExtSelectSortByFuelCons(min, max).ExtUnitsPrint(ConsoleColor.Cyan);
        }

        public void PrintUnitsSortedByMaxSpeed<T>()
        {
            PrintUnitsSortedByMaxSpeedInRange<T>(0, 0);
        }

        public void PrintUnitsSortedByMaxSpeedInRange<T>(double min, double max)
        {
            TUnits.ExtUnitsSelectByType<T>().ExtSelectSortByMaxSpeed(min, max).ExtUnitsPrint(ConsoleColor.Cyan);
        }

        public void PrintUnitsSortedByCostValue<T>()
        {
            PrintUnitsSortedByCostValueInRange<T>(0, 0);
        }

        public void PrintUnitsSortedByCostValueInRange<T>(double min, double max)
        {
            TUnits.ExtUnitsSelectByType<T>().ExtSelectSortByCostValue(min, max).ExtUnitsPrint(ConsoleColor.Cyan);
        }

        public void PrintUnitsSortedByWayRange<T>()
        {
            PrintUnitsSortedByWayRangeInRange<T>(0, 0);            
        }

        public void PrintUnitsSortedByWayRangeInRange<T>(double min, double max)
        {            
            TUnits.ExtUnitsSelectByType<T>().ExtSelectSortByWayRange(min, max).ExtUnitsPrint(ConsoleColor.Cyan);
        }

        public void PrintUnits()
        {
            TUnits.ExtUnitsPrint(ConsoleColor.Green);            
        }

        public void PrintUnits<T>()
        {
            TUnits.ExtUnitsSelectByType<T>().ExtUnitsPrint(ConsoleColor.Green);
        }
        #endregion

        #region Values
        public int CostValue<T>()
        {
            int costvalue = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IisMaterialValue))
                    costvalue += (item as IisMaterialValue).CostValue;
            }
            return costvalue;
        }

        public double WeightCapacity<T>()
        {
            double weightcapacity = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IhasBaggage))
                    weightcapacity += (item as IhasBaggage).WeightCapacity;
            }
            return weightcapacity;
        }

        public double VolumeCapacity<T>()
        {
            double volumecapacity = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IhasBaggage))
                    volumecapacity += (item as IhasBaggage).VolumeCapacity;
            }
            return volumecapacity;
        }
        #endregion
    }
}
