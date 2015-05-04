using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Traffic : ICollection<IUnit>
    {
        private ICollection<IUnit> traffic = new List<IUnit>();

        #region ICollection<IUnit> traffic
        public void Add(IUnit item)
        {
            traffic.Add(item);
        }

        public void Clear()
        {
            traffic.Clear();
        }

        public bool Contains(IUnit item)
        {
            return traffic.Contains(item);
        }

        public void CopyTo(IUnit[] array, int arrayIndex)
        {
            traffic.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return traffic.Count; }
        }

        public bool IsReadOnly
        {
            get { return traffic.IsReadOnly; }
        }

        public bool Remove(IUnit item)
        {
            return traffic.Remove(item);
        }

        public IEnumerator<IUnit> GetEnumerator()
        {
            return traffic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        

    }
}
