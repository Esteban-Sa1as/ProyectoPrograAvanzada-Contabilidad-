using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class UsuariosController : Controller
    {

        //Declare usuarios model
        UsuariosModel usuariosModel = new UsuariosModel();

        // GET: Usuarios
        [HttpGet]
        public ActionResult ListaUsuarios()
        {
            try
            {
                var resultado = usuariosModel.consultarUsuarios(); 
                return View(resultado);

            } catch(Exception ex)
            {
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult consultarUsuario(int idUsuario) {

            var resultado = usuariosModel.consultarUsuario(idUsuario); 
            return Json(resultado,JsonRequestBehavior.AllowGet);   
        }

        [HttpPost]
        public ActionResult actualizarUsuario(int idUsuario, string nombreUsuario, int idRoleUsuario)
        {

            UsuarioEnt usuarioActualizar = new UsuarioEnt
            {
                idUsuario = idUsuario,
                nombre = nombreUsuario,
                idRole = idRoleUsuario
            };

            var resultado = usuariosModel.actualizarUsuario(usuarioActualizar); 
            return Json(resultado,JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult buscarCorreo(string correo)
        {
            var resultado = usuariosModel.buscarCorreo(correo);
            return Json(resultado,JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public ActionResult crearUsuario(string correoElectronico, string nombre, int role)
        {
            UsuarioEnt nuevoUsuario = new UsuarioEnt();

            nuevoUsuario.correo = correoElectronico;
            nuevoUsuario.nombre= nombre;
            nuevoUsuario.role = role.ToString();

            var resultado = usuariosModel.crearUsuario(nuevoUsuario); 
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult activarUsuario (int idUsuario)
        {
            var resultado = usuariosModel.activarUsuario(idUsuario);
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult desactivarUsuario(int idUsuario)
        {
            var resultado = usuariosModel.desactivarUsuario(idUsuario);
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

    }

}
