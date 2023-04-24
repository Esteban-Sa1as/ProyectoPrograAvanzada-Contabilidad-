using Proyecto.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.ModelBinding;

namespace Proyecto.Controllers
{
    public class UsuariosModel
    {
        public List<UsuarioEnt> consultarUsuarios()
        {

            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/optenerUsuarios";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",HttpContext.Current.Session["TokenUsuario"].ToString());

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
                }

                return new List<UsuarioEnt>();
            }

        }

        public UsuarioEnt consultarUsuario(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/consultarUsuario?idUsuario=" + idUsuario.ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result; 
                }

                return new UsuarioEnt();
            }
        }

        public string buscarCorreo(string correoElectronico)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/buscarCorreo?correoElectronico=" + correoElectronico;

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<string>().Result;

                return "ERROR";
            }
        }

        public UsuarioEnt validarUsuario(UsuarioEnt usuario)
        {
            using(var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/validarUsuario";

                JsonContent body = JsonContent.Create(usuario);

                HttpResponseMessage res = client.PostAsync(url,body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result; 
                }

                return null; 

            }
        }

        public int crearUsuario(UsuarioEnt usuario)
        {
            
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/crearUsurio";


                JsonContent body = JsonContent.Create(usuario);

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result;
                }
                return 0;
            }
        }

        public int actualizarUsuario(UsuarioEnt usuarioActualizar)
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44328/api/actualizarUsuario";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());

                JsonContent body = JsonContent.Create(usuarioActualizar);

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult(); 

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                }

                return 0;

            }
        }

        public int activarUsuario(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/activarUsuario?idUsuario=" + idUsuario.ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result;
                }
                return 0;

            }
        }

        public int desactivarUsuario(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/desactivarUsuario?idUsuairo=" + idUsuario.ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 
                
                if (res.IsSuccessStatusCode) {
                    return res.Content.ReadFromJsonAsync<int>().Result;
                }
                return 0; 
            }
        }

        public int RestaurarContraseña(UsuarioEnt usuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/restaurarContrasenna";
                JsonContent body = JsonContent.Create(usuario); 

                HttpResponseMessage res = client.PutAsync(url,body).GetAwaiter().GetResult(); 

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                } return 0;
            }
        }

        public int cambiarContraseña(UsuarioEnt usuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/cambiarContrasenna";
                JsonContent body = JsonContent.Create(usuario);

                HttpResponseMessage res = client.PutAsync(url, body).GetAwaiter().GetResult(); 

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                } return 0; 
            }
        }

    }
}