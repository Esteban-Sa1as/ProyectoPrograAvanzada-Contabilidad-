using Proyecto.Entities;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {

        ConciliacionModel conciliacionModel = new ConciliacionModel();
        UsuariosModel usuarioModel = new UsuariosModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Principal(UsuarioEnt usuario)
        {
            UsuarioEnt usuarioLogged = usuarioModel.validarUsuario(usuario);

            if (usuarioLogged != null)
            {
                Session["NombreUsuario"] = usuarioLogged.nombre; 
                Session["CodigoUsuario"] = usuarioLogged.idUsuario;
                Session["RoleUsuario"] = usuarioLogged.idRole; 

                var resultado = conciliacionModel.cargarIndicadores(usuarioLogged.idUsuario);
                return View(resultado);

            } else
            {
                ViewBag.mensajeError = "Sus credenciales son incorrectas, intente nuevamente";
                return View("Index");
            }

            
        }


        [HttpGet]
        public ActionResult dashboard()
        {
            int idUsuario = (int)Session["CodigoUsuario"];

            var resultado = conciliacionModel.cargarIndicadores(idUsuario);
            return View("Principal", resultado);
        }

        
        [HttpGet]
        public ActionResult cargarIndicadores() 
        {

            int idUsuario = (int)Session["CodigoUsuario"]; 

            var resultado = conciliacionModel.cargarIndicadores(idUsuario);
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}