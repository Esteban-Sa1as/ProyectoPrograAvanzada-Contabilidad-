using Microsoft.Ajax.Utilities;
using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto.Models
{
    public class ConciliacionModel
    {

        public List<ConciliacionEnt> consultarConciliacion()
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44328/api/consultarConciliacion";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<List<ConciliacionEnt>>().Result;
                }

                return new List<ConciliacionEnt>();
            }
        }

        public IndicadoresEnt cargarIndicadores(int idUsuario)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/indidcadores/optenerIndicadores?idUsuario=" + idUsuario.ToString();

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<IndicadoresEnt>().Result;
                }

                return new IndicadoresEnt();
            }
        }
    }

}