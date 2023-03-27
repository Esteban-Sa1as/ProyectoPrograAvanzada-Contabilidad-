using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Models
{
    public class ClasesModel
    {
        public List<ClaseEnt> consultarClase()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/obtenerListaClases";


                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",HttpContext.Current.)
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    //Get the list of provinces. 
                    var listaClases = res.Content.ReadFromJsonAsync<List<ClaseEnt>>().Result;

                    return listaClases;
                }
                return new List<ClaseEnt>();
            }
        }



        public List<SelectListItem> seleccionarClase()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/obtenerListaClases";


                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",HttpContext.Current.)
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    //Get the list of provinces. 
                    var listaClases = res.Content.ReadFromJsonAsync<List<ClaseEnt>>().Result;

                    List<SelectListItem> listaDropdown = new List<SelectListItem>();

                    listaDropdown.Add(new SelectListItem
                    {
                        Text = "Seleccione la clase",
                        Value = "0"
                    });

                    foreach (var clase in listaClases)
                    {
                        listaDropdown.Add(new SelectListItem
                        {
                            Text = clase.descripcionClase,
                            Value = clase.idClase.ToString()
                        });
                    }

                    return listaDropdown;

                }

                return new List<SelectListItem>();

            }
        }

        public List<AuxiliarEnt> ejecutarDepreciacion(int idClase, string descripcionAsiento) 
        {
            using (var client = new HttpClient())
            {

                //Create a class to be sent to the API. 
                ClaseEnt claseDepreciada = new ClaseEnt();
                claseDepreciada.asientoDepreciacion = new AsientoEnt();

                claseDepreciada.idClase = idClase;
                claseDepreciada.asientoDepreciacion.descripcion = descripcionAsiento;

                //Perform request to the API. 
                string url = "https://localhost:44328/api/ejecutarDepreciacionClase";

                JsonContent body = JsonContent.Create(claseDepreciada);
                
                HttpResponseMessage res = client.PostAsync(url,body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<List<AuxiliarEnt>>().Result; 
                }

                return new List<AuxiliarEnt>();
            }
        }

    }
}