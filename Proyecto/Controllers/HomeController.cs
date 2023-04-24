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
    public class HomeController : Controller
    {

        ConciliacionModel conciliacionModel = new ConciliacionModel();
        UsuariosModel usuarioModel = new UsuariosModel();
        ErroresModel error = new ErroresModel();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult recuperarContraseña()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                ViewBag.mensajeError = "Sus credenciales son incorrectas, intente nuevamente";
                return View("Index");
            }
            
        }

        public ActionResult RestaurarContraseña(UsuarioEnt usuario) {

            try
            {
                var resultado = usuarioModel.RestaurarContraseña(usuario); 

                if(resultado == 0)
                {
                    ViewBag.mensajeError = "Al parecer el usuario seleccionado no existe, intenta nuevamente";
                    return View("recuperarContraseña");
                } else
                {
                    ViewBag.mensajeError = "Se ha enviado una nueva contraseña";
                    return View("Index");
                }

            }
            catch (Exception)
            {
                ViewBag.mensajeError = "Correo Incorrecto";
                return View("Index");
            }
            
        }

        [SessionFilter]
        public ActionResult CambiarContraseña(UsuarioEnt usuario)
        {
            try
            {
                usuario.correo = Session["CorreoUsuario"].ToString();
                var resultado = usuarioModel.cambiarContraseña(usuario); 
                return View("Index");
            }
            catch (Exception)
            {
                ViewBag.mensajeError = "Error desconocido, intente nuevamente más tarde"; 
                return View("Index");
            }
        }

        public ActionResult Principal(UsuarioEnt usuario)
        {
            try
            {
                UsuarioEnt usuarioLogged = usuarioModel.validarUsuario(usuario);

                if (usuarioLogged != null)
                {
                    Session["NombreUsuario"] = usuarioLogged.nombre;
                    Session["CorreoUsuario"] = usuarioLogged.correo;
                    Session["CodigoUsuario"] = usuarioLogged.idUsuario;
                    Session["RoleUsuario"] = usuarioLogged.idRole;
                    Session["TokenUsuario"] = usuarioLogged.Token;

                    if (usuarioLogged.estadoContrasenna == 0)
                    {
                        return View("cambiarContraseña"); 
                    } else
                    {
                        var resultado = conciliacionModel.cargarIndicadores(usuarioLogged.idUsuario);
                        return View(resultado);
                    }

                }
                else
                {
                    ViewBag.mensajeError = "Sus credenciales son incorrectas, intente nuevamente";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                error.reportarError("Principal", ex.Message);
                return View("Index");
            }
                        
        }


        [HttpGet]
        [SessionFilter]
        public ActionResult dashboard()
        {
            try
            {
                int idUsuario = (int)Session["CodigoUsuario"];

                var resultado = conciliacionModel.cargarIndicadores(idUsuario);
                return View("Principal", resultado);
            }
            catch (Exception ex)
            {
                error.reportarError("dashboard", ex.Message);
                return View("Index");
            }

        }

        
        [HttpGet]
        [SessionFilter]
        public ActionResult cargarIndicadores() 
        {
            try
            {
                int idUsuario = (int)Session["CodigoUsuario"];

                var resultado = conciliacionModel.cargarIndicadores(idUsuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                error.reportarError("cargarIndicadores", ex.Message);
                return View("Index");
            }

        }

        [SessionFilter]
        public ActionResult CerrarSession()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                error.reportarError("CerrarSession", ex.Message);
                return View("Index");
            }
            
        }
    }
}