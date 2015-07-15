using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckPoint05.Models;

namespace CheckPoint05.Controllers
{
    public class HomeController : Controller
    {
        IRepository<OrderUnit> OrdersRepository;

        public HomeController()
        {
            OrdersRepository = new Repository();
        }

        [HttpGet]
        public ActionResult EditRecord(int id)
        {            
            OrderUnit ou = OrdersRepository.GetOrder(id);
            if (ou == null)
            {
                return HttpNotFound();
            }
            return View(ou);
        }

        [HttpPost]
        [Authorize (Roles = "admin")]
        public ActionResult EditRecord(OrderUnit ou)
        {
            OrdersRepository.UpdateOrder(ou);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Index(string sortOrder, string searchStringManager, string searchStringProduct)
        {            
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "OrderID desc" : "";
            ViewBag.ManagerSortParm = sortOrder == "Manager" ? "Manager desc" : "Manager";
            ViewBag.CustomerSortParm = sortOrder == "Customer" ? "Customer desc" : "Customer";
            ViewBag.ProductSortParm = sortOrder == "Product" ? "Product desc" : "Product";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "Amount desc" : "Amount";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            IEnumerable<OrderUnit> orders = OrdersRepository.GetAllOrders();

            if (!String.IsNullOrEmpty(searchStringManager))
            {
                orders = orders.Where(s => s.ManagerName.ToUpper().Contains(searchStringManager.ToUpper()));
            }

            if (!String.IsNullOrEmpty(searchStringProduct))
            {
                orders = orders.Where(s => s.ProductName.ToUpper().Contains(searchStringProduct.ToUpper()));
            }

            switch (sortOrder)      
            {
                case "OrderID desc":
                    orders = orders.OrderByDescending(s => s.OrderID);
                    break;
                case "Manager":
                    orders = orders.OrderBy(s => s.ManagerName);
                    break;
                case "Manager desc":
                    orders = orders.OrderByDescending(s => s.ManagerName);
                    break;
                case "Customer":
                    orders = orders.OrderBy(s => s.CustomerName);
                    break;
                case "Customer desc":
                    orders = orders.OrderByDescending(s => s.CustomerName);
                    break;
                case "Product":
                    orders = orders.OrderBy(s => s.ProductName);
                    break;
                case "Product desc":
                    orders = orders.OrderByDescending(s => s.ProductName);
                    break;
                case "Amount":
                    orders = orders.OrderBy(s => s.Amount);
                    break;
                case "Amount desc":
                    orders = orders.OrderByDescending(s => s.Amount);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.Date);
                    break;
                case "Date desc":
                    orders = orders.OrderByDescending(s => s.Date);
                    break;
                default:
                    break;
            }
            ViewBag.Orders = orders;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
