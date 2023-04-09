﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entities
{
    public class AuxiliarEnt
    {
        public int idActivo { get; set; }
        public string descripcionActivo { get; set; }
        public double valorAdquisicion { get; set; }
        public DateTime fechaAdquisicion { get; set; }
        public int periodosDepreciados { get; set; }
        public string descripcionClase { get; set; }
        public int vidaUtil { get; set; }
        public int idClase { get; set; }
        public double depreciacionMensual { get; set; }
        public double depreciacionAcumulada { get; set; }
    }
}