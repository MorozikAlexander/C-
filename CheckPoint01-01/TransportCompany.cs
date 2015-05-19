using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class TransportCompany : IList<TransportUnit>
    {
        private IList<TransportUnit> TUnits = new List<TransportUnit>();        
        public string CompanyName { get; set; }

        public TransportCompany(string CN)
        {
            CompanyName = CN;
        }

        #region IList<TransportUnit>
        public int IndexOf(TransportUnit item)
        {
            return TUnits.IndexOf(item);
        }

        public void Insert(int index, TransportUnit item)
        {
            TUnits.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            TUnits.RemoveAt(index);
        }        

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

        public void CopyTo(TransportUnit[] array, int arrayIndex)
        {
            TUnits.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return TUnits.Count; }
        }

        public bool IsReadOnly
        {
            get { return TUnits.IsReadOnly; }
        }

        public bool Remove(TransportUnit item)
        {
            return TUnits.Remove(item);
        }

        public IEnumerator<TransportUnit> GetEnumerator()
        {
            return TUnits.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Sorting
        protected void Sort(IComparer<TransportUnit> comparer)
        {
            var newList = TUnits.ToList();            
            newList.Sort(comparer);
            TUnits = newList;
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

        public void SortByFuelCons<T>()
        {
            SortByFuelCons<T>(0, 0);
        }

        public void SortByFuelCons<T>(double min, double max)
        {
            IEnumerable<T> newList = new List<T>();
            newList = TUnits.OfType<T>();            
            if (newList.Count<T>() > 0)
            {
                newList = from c in newList orderby ((c as IisTransport).FuelCons) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).FuelCons >= min) && ((c as IisTransport).FuelCons <= max)) select c;
                PrintUnitsRange<T>(newList.ToList<T>(), ConsoleColor.Cyan);
            }            
        }

        public void SortByMaxSpeed<T>()
        {
            SortByMaxSpeed<T>(0, 0);
        }

        public void SortByMaxSpeed<T>(double min, double max)
        {
            IEnumerable<T> newList = new List<T>();
            newList = TUnits.OfType<T>();
            if (newList.Count<T>() > 0)
            {
                newList = from c in newList orderby ((c as IisTransport).MaxSpeed) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).MaxSpeed >= min) && ((c as IisTransport).MaxSpeed <= max)) select c;
                PrintUnitsRange<T>(newList.ToList<T>(), ConsoleColor.Cyan);
            }
        }

        public void SortByCostValue<T>()
        {
            SortByCostValue<T>(0, 0);
        }

        public void SortByCostValue<T>(double min, double max)
        {
            IEnumerable<T> newList = new List<T>();
            newList = TUnits.OfType<T>();
            if (newList.Count<T>() > 0)            
            {
                newList = from c in newList orderby ((c as IisMaterialValue).CostValue) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisMaterialValue).CostValue >= min) && ((c as IisMaterialValue).CostValue <= max)) select c;
                PrintUnitsRange<T>(newList.ToList<T>(), ConsoleColor.Cyan);
            }
        }

        public void SortByWayRange<T>()
        {
            SortByWayRange<T>(0, 0);
        }

        public void SortByWayRange<T>(double min, double max)
        {
            IEnumerable<T> newList = new List<T>();
            newList = TUnits.OfType<T>();
            if (newList.Count<T>() > 0)
            {
                newList = from c in newList orderby ((c as IisTransport).WayRange) select c;
                if ((max > 0) && (max > min))
                    newList = from c in newList where (((c as IisTransport).WayRange >= min) && ((c as IisTransport).WayRange <= max)) select c;
                PrintUnitsRange<T>(newList.ToList<T>(), ConsoleColor.Cyan);
            }
        }
        #endregion

        #region Prints
        public void PrintUnits()
        {
            PrintUnitsRange<TransportUnit>(TUnits.ToList<TransportUnit>(), ConsoleColor.Green);
        }

        public void PrintUnitsRange<T>(List<T> RangeList, ConsoleColor color)
        {            
            if (RangeList != null)
                for (int i = 0; i < RangeList.Count; i++)
                {
                    Console.ForegroundColor = color;
                    Console.Write("{0,2} {1,5} ", i + 1, (RangeList[i] as TransportUnit).ID);
                    Console.Write("{0,8} ", (RangeList[i] as TransportUnit).kindofunit);

                    if (RangeList[i] is ManUnit) Console.Write("{0,-15}", (RangeList[i] as TransportUnit).Name + ' ' + (RangeList[i] as ManUnit).FirstName);
                    else Console.Write("{0,-15}", (RangeList[i] as TransportUnit).Name);

                    if (RangeList[i] is AircraftUnit)
                    {
                        Console.Write("FC:{0,5} ", (RangeList[i] as IisTransport).FuelCons);
                        Console.Write("MS:{0,5} ", (RangeList[i] as IisTransport).MaxSpeed);
                        Console.Write("FV:{0,5} ", (RangeList[i] as IisTransport).FuelValue);
                        Console.Write("VC:{0,5} ", (RangeList[i] as IhasPassenger).VolumeCapacity);
                        Console.WriteLine("WC:{0,5} ", (RangeList[i] as IhasPassenger).WeightCapacity);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("          RANGE:{0,30} km", (RangeList[i] as IisTransport).WayRange);
                        Console.ForegroundColor = color;
                    }
                    else if (RangeList[i] is CarUnit)
                    {
                        Console.Write("FC:{0,5} ", (RangeList[i] as IisTransport).FuelCons);
                        Console.Write("MS:{0,5} ", (RangeList[i] as IisTransport).MaxSpeed);
                        Console.Write("CV:{0,7} ", (RangeList[i] as CarUnit).CostValue);
                    }
                    else if (RangeList[i] is DriverUnit)
                    {
                        Console.Write("Drive lisences: ");
                        if ((RangeList[i] as DriverUnit).CarDriveLicense) Console.Write(" #CAR# ");
                        if ((RangeList[i] as DriverUnit).TrainDriveLicense) Console.Write(" #TRAIN# ");
                        if ((RangeList[i] as DriverUnit).AircraftDriveLicense) Console.Write(" #AIRCRAFT# ");                        
                    }
                    else if (RangeList[i] is BaggageUnit)
                    {
                        Console.Write("VOLUME:{0,7} ", (RangeList[i] as BaggageUnit).Volume);
                        Console.Write("WEIGHT:{0,7} ", (RangeList[i] as BaggageUnit).Weight);
                    }

                    Console.WriteLine();
                }
            Console.WriteLine();
        }
        #endregion

        #region Values
        public int CostValue<T>()
        {
            int CV = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IisMaterialValue))
                    CV += (item as IisMaterialValue).CostValue;
            }
            return CV;
        }

        public double WeightCapacity<T>()
        {
            double WC = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IhasBaggage))
                    WC += (item as IhasBaggage).WeightCapacity;
            }
            return WC;
        }

        public double VolumeCapacity<T>()
        {
            double VC = 0;
            foreach (var item in TUnits)
            {
                if ((item is T) && (item is IhasBaggage))
                    VC += (item as IhasBaggage).VolumeCapacity;
            }
            return VC;
        }
        #endregion
    }
}
