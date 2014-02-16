using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Message of the day: ";
            ViewBag.CurrentMessage = @"'Here lays the future, but only its remains...'";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "All About Us....";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us....";

            return View();
        }
    }
}
