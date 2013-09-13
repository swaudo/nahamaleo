using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nahamaleo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult compare()
        {

            return View();
        }

        public ActionResult listings()
        {

            return View();
        }

        public ActionResult map_properties()
        {

            return View();
        }
        public ActionResult property()
        {

            return View();
        }

        public ActionResult terms()
        {

            return View();
        }

    }
}
