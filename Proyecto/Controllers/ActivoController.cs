using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ActivoController : Controller
    {

        ActivoModel activoModel = new ActivoModel();

        [HttpGet]
        public ActionResult detalleActivos()
        {
            var result = activoModel.consultarAuxiliarActivos(); 
            return View(result);
        }

        [HttpGet]
        public ActionResult detalleActivo(int idActivo)
        {
            var result = activoModel.consultarActivo(idActivo);
            return View("detalleActivo",result);
        }

    }
}