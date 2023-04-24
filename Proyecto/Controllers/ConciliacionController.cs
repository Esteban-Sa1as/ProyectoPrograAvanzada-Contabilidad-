using Proyecto.Models;
using Sem1_ProyectoWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    [SessionFilter]
    public class ConciliacionController : Controller
    {
        //Declare recon model
        ConciliacionModel conciliacionModel = new ConciliacionModel();
        ErroresModel error = new ErroresModel();

        [HttpGet]
        public ActionResult Conciliacion()
        {
            try
            {
                var resultado = conciliacionModel.consultarConciliacion();
                return View(resultado);
            }
            catch (Exception ex)
            {
                error.reportarError("Conciliacion", ex.Message);
                return View("Index");
            }
        }
    }
}
