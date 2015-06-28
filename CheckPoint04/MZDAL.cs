using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckPoint04
{
    public class MZDAL
    {
        private MZDBEntities context;

        public MZDAL()
        {
            context = new MZDBEntities();
        }

        public Exception AddOrderUnit(OrderUnit item)
        {
            using (context = new MZDBEntities())
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
