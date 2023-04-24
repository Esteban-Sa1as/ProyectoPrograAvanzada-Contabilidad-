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
    public class ClaseController : Controller
    {
        ClasesModel modelClases = new ClasesModel();
        ErroresModel error = new ErroresModel();
        public ActionResult ListarClases()
        {
            try
            {
                var result = modelClases.consultarClase();
                return View(result);
            }
            catch (Exception ex)
            {
                error.reportarError("ListarClases", ex.Message);
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult optenerClases()
        {
            try
            {
                var result = modelClases.consultarClase();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("optenerClases", ex.Message);
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult buscarInformacionClase(string idClase)
        {
            try
            {
                var result = modelClases.buscarInformacionClase(Convert.ToInt16(idClase));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("buscarInformacionClase", ex.Message);
                return View("Index");
            }
            
        }


        [HttpGet]
        public ActionResult EjecutarDepreciacion()
        {
            try
            {
                ViewBag.listaClases = modelClases.seleccionarClase();
                return View();
            }
            catch (Exception ex)
            {
                error.reportarError("EjecutarDepreciacion", ex.Message);
                return View("Index");
            }
            
        }

        [HttpPost]
        public ActionResult EjecutarDepreciacion(int idClase, string descripcionAsiento)
        {
            try
            {
                var resultado = modelClases.ejecutarDepreciacion(idClase, descripcionAsiento);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("EjecutarDepreciacion", ex.Message);
                return View("Index");
            }
            
        }

        public ActionResult crearClase(string clase, int vidaUtil, string activo, string gasto, string depAc)
        {
            try
            {
                ClaseEnt nuevaClase = new ClaseEnt();

                nuevaClase.descripcionClase = clase;
                nuevaClase.vidaUtil = vidaUtil;
                nuevaClase.cuentaActivo = new CuentaContableEnt { idCuenta = activo };
                nuevaClase.cuentaGasto = new CuentaContableEnt { idCuenta = gasto };
                nuevaClase.cuentaDepAcumulada = new CuentaContableEnt { idCuenta = depAc };


                var resultado = modelClases.crearClase(nuevaClase);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("crearClase", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult crearValidacionClase(string idClase, string descripcionValidacion)
        {
            try
            {
                ClaseEnt nuevaValidacion = new ClaseEnt
                {
                    idClase = Convert.ToInt32(idClase),
                    validacionClase = new ValidacionClaseEnt { descripcionValidacion = descripcionValidacion }
                };

                var resultado = modelClases.crearValidacionClase(nuevaValidacion);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("crearValidacionClase", ex.Message);
                return View("Index");
            }
           
        }
    }
}
