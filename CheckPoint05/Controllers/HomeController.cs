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
        public DalUnit DU = new DalUnit();

        [HttpGet]
        public ActionResult EditRecord(int id)
        {
            //ViewBag.OrderUnit = DU.GetOrder(id);
            OrderUnit ou = DU.GetOrder(id);
            if (ou == null)
            {
                return HttpNotFound();
            }
            return View(ou);
        }

        [HttpPost]
        public ActionResult EditRecord(OrderUnit ou)
        {
            DU.UpdateOrder(ou);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            IEnumerable<OrderUnit> orders = DU.GetAllOrders();
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
