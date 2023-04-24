using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto.Models
{
    public class ErroresModel
    {

        public void reportarError(string pantalla, string mensajeError)
        {
            using (var client = new HttpClient())
            {

                ErrorEnt error = new ErrorEnt
                {
                    pantalla = pantalla,
                    error = mensajeError
                };

                string url = "https://localhost:44328/api/error/reportarError"; 
                JsonContent body = JsonContent.Create(error);

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

            }
        }


    }
}