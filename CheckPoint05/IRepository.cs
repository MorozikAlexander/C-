using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint05.Models;

namespace CheckPoint05
{
    public interface IRepository<T> : IDisposable
            where T : OrderUnit
    {
        IEnumerable<T> GetAllOrders();
        T GetOrder(int id);
        void CreateOrder(T item);
        void UpdateOrder(T item);
        void DeleteOrder(int id);
        void Save();
    }
}
