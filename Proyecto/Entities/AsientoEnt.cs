using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entities
{
    public class AsientoEnt
    {
        public int idAsiento { get; set; }
        public ClaseEnt clase { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public List<AsientoLineasEnt> cuerpoAsiento { get; set; }
    }
}