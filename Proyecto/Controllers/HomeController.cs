using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {

        ConciliacionModel conciliacionModel = new ConciliacionModel();

        public ActionResult Index()
        {
            var resultado = conciliacionModel.cargarIndicadores(1);
            return View(resultado);
        }

        [HttpGet]
        public ActionResult cargarIndicadores(int idUsuario) 
        {
            var resultado = conciliacionModel.cargarIndicadores(1);
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}