using ExaParcialMondalgo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExaParcialMondalgo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Creacion()
        {
            //ViewBag.Message = "Your applicastion description page.";

            return RedirectToAction("Index", "Cines");
        }

        public ActionResult Peliculas()
        {
            //ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index", "Peliculas");
        }
    }
}
