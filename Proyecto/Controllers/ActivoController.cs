using Proyecto.Entities;
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

        public ActionResult editarValidacion(int idActivo, int idValidacion, string valor)
        {
            ValidacionClaseEnt nuevaValidacion = new ValidacionClaseEnt
            {
                idValidacion = idValidacion,
                idActivo = idActivo,
                valor = valor
            };

            var resultado = activoModel.editarValidacion(nuevaValidacion); 
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        public ActionResult agregarValidacion(int idActivo, int idValidacion, string valor)
        {
            ValidacionClaseEnt nuevaValidacion = new ValidacionClaseEnt
            {
                idValidacion = idValidacion,
                idActivo = idActivo,
                valor = valor
            };

            var resultado = activoModel.agregarValidacion(nuevaValidacion);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}