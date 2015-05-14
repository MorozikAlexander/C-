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
        //private List<TransportUnit> temp = new List<TransportUnit>();
        public string CompanyName { get; set; }

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

        public TransportCompany(string CN)
        {
            CompanyName = CN;
        }

        protected void Sort(IComparer<TransportUnit> comparer)
        {
            var newList = TUnits.ToList();
            
            newList.Sort(comparer);
            TUnits = newList;
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
            IEnumerable<T> newList = new List<T>();
            newList = TUnits.OfType<T>();
            
            if (newList != null)
            {
                newList = from c in newList orderby ((c as IisTransport).FuelCons) select c;
                PrintUnitsRange<T>(newList.ToList<T>(), ConsoleColor.Cyan);
            }            
        }

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
                    Console.Write("{0,10} ", (RangeList[i] as TransportUnit).kindofunit);
                    
                    if (RangeList[i] is ManUnit)
                        //Console.WriteLine("{0,25}", String.Concat(TUnits[i].Name, (TUnits[i] as ManUnit).LastName));                
                        Console.Write("{0,-15}", (RangeList[i] as ManUnit).LastName + ' ' + (RangeList[i] as TransportUnit).Name);
                    else Console.Write("{0,-15}", (RangeList[i] as TransportUnit).Name);

                    if (RangeList[i] is IisTransport)
                    {

                        Console.Write("{0,10}", (RangeList[i] as IisTransport).FuelCons);
                        Console.Write("{0,10}", (RangeList[i] as IisTransport).MaxSpeed);
                        Console.Write("{0,10}", (RangeList[i] as IisTransport).FuelValue);

                    }
                    Console.WriteLine();
                }
            Console.WriteLine();

        }



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

        public IEnumerable<T> ExtractUnits<T>()
        {
            //IEnumerable<T> dd = from c in TUnits where (c is T) select c;

            //IEnumerable<T> Result = from c in TUnits where (c is T) select c;

            //return from c in TUnits where (c is T) select c;

            return TUnits.OfType<T>();
            

        }






    }
}
