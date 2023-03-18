using Proyecto.Entities;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClaseController : Controller
    {
        ClasesModel modelClases = new ClasesModel();
        
        [HttpGet]
        public ActionResult EjecutarDepreciacion()
        {

            ViewBag.listaClases = modelClases.seleccionarClase(); 
            return View();
        }

        [HttpPost]
        public ActionResult EjecutarDepreciacion(int idClase, string descripcionAsiento)
        {
            var resultado  = modelClases.ejecutarDepreciacion(idClase, descripcionAsiento);
            return Json(resultado,JsonRequestBehavior.AllowGet);
            
        }

    }
}
