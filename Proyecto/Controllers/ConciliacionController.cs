using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ConciliacionController : Controller
    {
        //Declare recon model
        ConciliacionModel conciliacionModel = new ConciliacionModel();

        [HttpGet]
        public ActionResult Conciliacion()
        {
            try
            {
                var resultado = conciliacionModel.consultarConciliacion();
                return View(resultado);
            }
            catch (Exception)
            {
                return View("Index"); 
                throw;
            }
        }
    }
}
