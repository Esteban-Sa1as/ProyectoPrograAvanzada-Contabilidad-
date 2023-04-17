using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto.Models
{
    public class AsientoModel
    {

        public List<AsientoEnt> consultarAsientos()
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44328/api/asiento/consultarAsientos";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<List<AsientoEnt>>().Result;
                }

                return new List<AsientoEnt>();

            }

        }

        public AsientoEnt consultarAsiento(int idAsiento)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/asiento/" + idAsiento.ToString();

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<AsientoEnt>().Result;
                }

                return new AsientoEnt();
            }
        }

    }
}