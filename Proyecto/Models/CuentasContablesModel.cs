using Proyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto.Models
{
    public class CuentasContablesModel
    {

        public List<CuentaContableEnt> consultarCuentas()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/cuentas/optenerCuentas";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 

                if (res.IsSuccessStatusCode) {

                    return res.Content.ReadFromJsonAsync<List<CuentaContableEnt>>().Result; 
                }

                return new List<CuentaContableEnt>(); 
            }
        }


        public CuentaContableEnt validarCuentaDuplicada(string idCuentaContable)
        {
            using(var client = new HttpClient()) {
                
                string url = "https://localhost:44328/api/cuentas/buscarCuenta?idCuenta=" + idCuentaContable;

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult(); 

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<CuentaContableEnt>().Result;
                }

                return null; 

            }
        }

        public int CrearCuentaContable(CuentaContableEnt cuentaContable)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44328/api/cuentas/crearCuenta"; 

                JsonContent body = JsonContent.Create(cuentaContable);

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult(); 

                if(res.IsSuccessStatusCode)
                {
                    return res.Content.ReadFromJsonAsync<int>().Result; 
                }
                return 0; 

            }
        }

    }
}