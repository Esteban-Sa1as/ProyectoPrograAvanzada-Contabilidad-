using Proyecto.Entities;
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
    public class AsientosController : Controller
    {
        AsientosModel asientosModel = new AsientosModel();
        ErroresModel error = new ErroresModel();
        
        public ActionResult Index()
        {
            try
            {
                var Asientos = asientosModel.consultarAsientos();
                return View(Asientos);
            }
            catch (Exception ex)
            {
                error.reportarError("ListaAsientos", ex.Message);
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult detalleAsiento(int idAsiento) {

            try
            {
                var Asiento = asientosModel.consultarAsiento(idAsiento);
                return View(Asiento);
            }
            catch (Exception ex)
            {
                error.reportarError("detalleAsiento", ex.Message);
                return View("Index");
            }
            
        }

    }
}