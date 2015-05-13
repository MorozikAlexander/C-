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

        public void PrintUnits()
        {
            if (TUnits != null)
            for (int i = 0; i < TUnits.Count; i++)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0,-10}", TUnits[i].kindofunit);
                Console.Write("{0,-3}{1,10} ", i+1, TUnits[i].ID);
                if (TUnits[i] is ManUnit)                
                    //Console.WriteLine("{0,25}", String.Concat(TUnits[i].Name, (TUnits[i] as ManUnit).LastName));                
                    Console.WriteLine("{0,-25}", (TUnits[i] as ManUnit).LastName + ' ' + TUnits[i].Name);                
                else Console.WriteLine("{0,-25}", TUnits[i].Name);                
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


    }
}
