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
    public class ActivoController : Controller
    {

        ActivoModel activoModel = new ActivoModel();
        ErroresModel error = new ErroresModel();

        [HttpGet]
        public ActionResult detalleActivos()
        {
            try
            {
                var result = activoModel.consultarAuxiliarActivos();
                return View(result);
            }
            catch (Exception ex)
            {
                error.reportarError("detalleActivos", ex.Message);
                return View("Index");
            }

        }

        [HttpGet]
        public ActionResult detalleActivo(int idActivo)
        {
            try
            {
                var result = activoModel.consultarActivo(idActivo);
                return View("detalleActivo", result);
            }
            catch (Exception ex)
            {
                error.reportarError("detalleActivo", ex.Message);
                return View("Index");
            }

        }

        public ActionResult editarValidacion(int idActivo, int idValidacion, string valor)
        {

            try
            {
                ValidacionClaseEnt nuevaValidacion = new ValidacionClaseEnt
                {
                    idValidacion = idValidacion,
                    idActivo = idActivo,
                    valor = valor
                };

                var resultado = activoModel.editarValidacion(nuevaValidacion);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("editarValidacion", ex.Message);
                return View("Index");
            }

        }

        public ActionResult agregarValidacion(int idActivo, int idValidacion, string valor)
        {

            try
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
            catch (Exception ex)
            {
                error.reportarError("agregarValidacion", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult CrearActivo(string descripcion, string valorAdquisición, string idClase, string idUbicacion, string idDuenno, string idEstado)
        {

            try
            {
                ActivoEnt nuevoActivo = new ActivoEnt
                {
                    descripcionActivo = descripcion,
                    valorAdquisicion = Convert.ToDouble(valorAdquisición),
                    fechaAdquiscion = DateTime.Now,
                    claseActivo = new ClaseEnt { idClase = Convert.ToInt32(idClase) },
                    ubicacionActivo = new UbicacionEnt { idUbicacíon = Convert.ToInt32(idUbicacion) },
                    duennoActivo = new UsuarioEnt { idUsuario = Convert.ToInt32(idDuenno) },
                    estadoActivo = new EstadoEnt { idEstado = Convert.ToInt32(idEstado) }
                };

                var resultado = activoModel.CrearActivo(nuevoActivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("CrearActivo", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult modificarClase(string idActivo, string idNuevaClase)
        {

            try
            {
                ActivoEnt activoModificar = new ActivoEnt
                {
                    idActivo = Convert.ToInt32(idActivo),
                    claseActivo = new ClaseEnt { idClase = Convert.ToInt32(idNuevaClase) }
                };

                var resultado = activoModel.modificarClase(activoModificar);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("modificarClase", ex.Message);
                return View("Index");
            }

        }
    }
}