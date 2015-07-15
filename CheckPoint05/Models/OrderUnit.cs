using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckPoint05.Models
{
    public class OrderUnit
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string ManagerName { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}