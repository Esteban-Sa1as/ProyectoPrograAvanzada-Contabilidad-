using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto.Models
{
    public class ActivoModel
    {

        public List<AuxiliarEnt> consultarAuxiliarActivos()
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44328/api/activo/consultarAuxiliarActivos";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<List<AuxiliarEnt>>().Result;
                }

                return new List<AuxiliarEnt>(); 

            }

        }

        public ActivoEnt consultarActivo(int idActivo)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/activo/consultarActivo?idActivo=" + idActivo.ToString();

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<ActivoEnt>().Result;
                }

                return new ActivoEnt();
            }
        }

        public int editarValidacion (ValidacionClaseEnt nuevaValidacion)
        {

            using (var client = new HttpClient())
            {

                string url = "https://localhost:44328/api/modificarValidacionActivo";

                JsonContent body = JsonContent.Create(nuevaValidacion);

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult(); 

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                }

                return 0; 
            }

        }

        public int agregarValidacion (ValidacionClaseEnt nuevaValidacion)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/agregarValidacionActivo"; 

                JsonContent body = JsonContent.Create(nuevaValidacion);

                HttpResponseMessage res = client.PostAsync(url,body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                }

                return 0; 

            }
        }

    }
}