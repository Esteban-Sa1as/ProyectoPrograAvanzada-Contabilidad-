using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entities
{
    public class ClaseEnt
    {
        public int idClase { get; set; }
        public string descripcionClase { get; set; }
        public int vidaUtil { get; set; }
        public AsientoEnt asientoDepreciacion { get; set; }
    }
}