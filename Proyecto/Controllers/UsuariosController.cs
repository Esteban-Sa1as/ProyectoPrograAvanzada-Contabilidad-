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
    public class UsuariosController : Controller
    {

        //Declare usuarios model
        UsuariosModel usuariosModel = new UsuariosModel();
        ErroresModel error = new ErroresModel();

        // GET: Usuarios
        [HttpGet]
        [SessionFilter]
        public ActionResult ListaUsuarios()
        {
            try
            {
                var resultado = usuariosModel.consultarUsuarios(); 
                return View(resultado);

            } catch(Exception ex)
            {
                error.reportarError("ListaUsuarios", ex.Message); 
                return View("Index");
            }
            
        }

        [HttpGet]
        [SessionFilter]
        public ActionResult consultarUsuarios()
        {

            try
            {
                var resultado = usuariosModel.consultarUsuarios();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("consultarUsuarios", ex.Message);
                return View("Index");
            }

        }

        [HttpGet]
        public ActionResult consultarUsuario(int idUsuario) {

            try
            {
                var resultado = usuariosModel.consultarUsuario(idUsuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("consultarUsuario", ex.Message);
                return View("Index");
            }
  
        }

        [HttpPost]
        [SessionFilter]
        public ActionResult actualizarUsuario(int idUsuario, string nombreUsuario, int idRoleUsuario)
        {
            try
            {
                UsuarioEnt usuarioActualizar = new UsuarioEnt
                {
                    idUsuario = idUsuario,
                    nombre = nombreUsuario,
                    idRole = idRoleUsuario
                };

                var resultado = usuariosModel.actualizarUsuario(usuarioActualizar);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("actualizarUsuario", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult buscarCorreo(string correo)
        {

            try
            {
                var resultado = usuariosModel.buscarCorreo(correo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("buscarCorreo", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        [SessionFilter]
        public ActionResult crearUsuario(string correoElectronico, string nombre, int role)
        {

            try
            {
                UsuarioEnt nuevoUsuario = new UsuarioEnt();

                nuevoUsuario.correo = correoElectronico;
                nuevoUsuario.nombre = nombre;
                nuevoUsuario.role = role.ToString();

                var resultado = usuariosModel.crearUsuario(nuevoUsuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("crearUsuario", ex.Message);
                return View("Index");
            }

        }

        [HttpPost]
        [SessionFilter]
        public ActionResult activarUsuario (int idUsuario)
        {
            
            try
            {
                var resultado = usuariosModel.activarUsuario(idUsuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("activarUsuario", ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        [SessionFilter]
        public ActionResult desactivarUsuario(int idUsuario)
        {
            try
            {
                var resultado = usuariosModel.desactivarUsuario(idUsuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("desactivarUsuario", ex.Message);
                return View("Index");
            }

        }

    }

}
