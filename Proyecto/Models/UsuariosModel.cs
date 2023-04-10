using Proyecto.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Proyecto.Controllers
{
    public class UsuariosModel
    {
        public List<UsuarioEnt> consultarUsuarios()
        {

            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/optenerUsuarios";

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

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 
                
                if (res.IsSuccessStatusCode) {
                    return res.Content.ReadFromJsonAsync<int>().Result;
                }
                return 0; 
            }
        }

    }
}