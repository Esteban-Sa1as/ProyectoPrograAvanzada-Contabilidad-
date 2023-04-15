using Proyecto.Entities;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class CuentasContablesController : Controller
    {

        CuentasContablesModel cuentasModel = new CuentasContablesModel();

        // GET: CuentasContables
        public ActionResult Index()
        {
            var resultados = cuentasModel.consultarCuentas(); 
            return View(resultados);
        }

        [HttpGet]
        public ActionResult consultarCuentaContable(string idCuentaContable)
        {
            var resultado = cuentasModel.validarCuentaDuplicada(idCuentaContable); 

            if (resultado != null)
            {
                return Json("La cuenta indicada ya existe",JsonRequestBehavior.AllowGet);

            } else
            {
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult CrearCuentaContable(string idCuenta, string descripcionCuenta, int idCategoria, string naturalezaCuenta)
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
            return Json(resultado,JsonRequestBehavior.AllowGet);

    }
    }

    
}