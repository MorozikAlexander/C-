using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckPoint05.Models;

namespace CheckPoint05
{
    public class Repository : IRepository<OrderUnit>
    {
        private DalUnit _dal;

        public Repository()
        {
            _dal = new DalUnit();
        }

        public IEnumerable<OrderUnit> GetAllOrders()
        {
            return _dal.GetAllOrders();
        }

        public OrderUnit GetOrder(int id)
        {
            return _dal.GetOrder(id);
        }

        public void CreateOrder(OrderUnit item)
        {
            _dal.AddOrder(item);
        }

        public void UpdateOrder(OrderUnit item)
        {
            _dal.UpdateOrder(item);
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dal.context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}