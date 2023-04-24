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
    public class CuentasContablesController : Controller
    {

        CuentasContablesModel cuentasModel = new CuentasContablesModel();
        ErroresModel error = new ErroresModel();

        // GET: CuentasContables
        public ActionResult Index()
        {
            try
            {
                var resultados = cuentasModel.consultarCuentas();
                return View(resultados);
            }
            catch (Exception ex)
            {
                error.reportarError("CuentasContables", ex.Message);
                return View("Index");
            }

            
        }

        [HttpGet]
        public ActionResult consultarCuentaContable(string idCuentaContable)
        {
            try
            {
                var resultado = cuentasModel.validarCuentaDuplicada(idCuentaContable);

                if (resultado != null)
                {
                    return Json("La cuenta indicada ya existe", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json("Ok", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                error.reportarError("consultarCuentaContable", ex.Message);
                return View("Index");
            }
            
        }

        public ActionResult consultarCuenta()
        {
            try
            {
                var resultado = cuentasModel.consultarCuentas();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("consultarCuenta", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult CrearCuentaContable(string idCuenta, string descripcionCuenta, int idCategoria, string naturalezaCuenta)
        {
            try
            {
                CuentaContableEnt nuevaCuenta = new CuentaContableEnt
                {
                    idCuenta = idCuenta,
                    descripcionCuenta = descripcionCuenta,
                    categoriaCuenta = new CategoriaCuentaEnt
                    {
                        idCategoria = idCategoria
                    },
                    totalDebitos = 0,
                    totalCreditos = 0,
                    naturaleza = naturalezaCuenta
                };

                var resultado = cuentasModel.CrearCuentaContable(nuevaCuenta);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("CrearCuentaContable", ex.Message);
                return View("Index");
            }

        }


        [HttpGet]
        public ActionResult validarCuentaContableClase(string cuentaContable)
        {
            try
            {
                Boolean validarCuenta = cuentasModel.validarCuentaContableClase(cuentaContable);
                return Json(validarCuenta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("validarCuentaContableClase", ex.Message);
                return View("Index");
            }

        }

    }    
}