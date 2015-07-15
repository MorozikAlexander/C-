using CheckPoint05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CheckPoint05
{
    public class DalUnit
    {
        public DBEntities context;

        public DalUnit()
        {
            context = new DBEntities();            
        }

        public bool UpdateOrder(OrderUnit item)
        {
            using (context = new DBEntities())
            {
                var searchitem = context.Orders.Find(item.OrderID);
                if (searchitem != null)
                {
                    searchitem.ManagerName = item.ManagerName;                                        
                    searchitem.CustomerName = item.CustomerName;
                    searchitem.Amount = item.Amount;
                    searchitem.ProductName = item.ProductName;
                    searchitem.Date = item.Date;
                    context.Entry(searchitem).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public OrderUnit GetOrder(int id)
        {
            using (context = new DBEntities())
            {
                var searchitem = context.Orders.Find(id);
                if (searchitem != null)
                {
                    OrderUnit ou = new OrderUnit()
                    {
                        OrderID = searchitem.OrderID,
                        ManagerName = searchitem.ManagerName,
                        CustomerName = searchitem.CustomerName,
                        Amount = searchitem.Amount,
                        ProductName = searchitem.ProductName,
                        Date = searchitem.Date
                    };
                    return ou;
                }
                else return null;
            }
        }

        public IEnumerable<OrderUnit> GetAllOrders()
        {
            using (context = new DBEntities())
            {
                foreach (OrdersRecord or in context.Orders)
                {
                    if (or != null)
                    {
                        OrderUnit ou = new OrderUnit();
                        ou.OrderID = or.OrderID;
                        ou.ManagerName = or.ManagerName;
                        ou.CustomerName = or.CustomerName;
                        ou.Amount = or.Amount;
                        ou.ProductName = or.ProductName;
                        ou.Date = or.Date;
                        yield return ou;                        
                    }
                }
            }
        }

        public Exception AddOrder(OrderUnit item)
        {
            using (context = new DBEntities())
            {
                try
                {
                    context.Orders.Add(new OrdersRecord()
                    {
                        ManagerName = item.ManagerName,
                        CustomerName = item.CustomerName,
                        Amount = item.Amount,
                        ProductName = item.ProductName,
                        Date = item.Date
                    });
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    return e;
                }
                return null;
            }
        }
    }
}