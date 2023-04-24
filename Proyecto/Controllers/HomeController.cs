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

        public ActionResult Principal(UsuarioEnt usuario)
        {
            try
            {
                UsuarioEnt usuarioLogged = usuarioModel.validarUsuario(usuario);

                if (usuarioLogged != null)
                {
                    Session["NombreUsuario"] = usuarioLogged.nombre;
                    Session["CodigoUsuario"] = usuarioLogged.idUsuario;
                    Session["RoleUsuario"] = usuarioLogged.idRole;
                    Session["TokenUsuario"] = usuarioLogged.Token;

                    var resultado = conciliacionModel.cargarIndicadores(usuarioLogged.idUsuario);
                    return View(resultado);

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
        

        public ActionResult About()
        {
            try
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            catch (Exception ex)
            {
                error.reportarError("About", ex.Message);
                return View("Index");
            }
           
        }

        public ActionResult Contact()
        {
            try
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            catch (Exception ex)
            {
                error.reportarError("Contact", ex.Message);
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