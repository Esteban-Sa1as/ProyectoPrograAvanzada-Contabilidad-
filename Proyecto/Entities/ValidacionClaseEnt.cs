﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entities
{
    public class ValidacionClaseEnt
    {
        // ---------------- Se usa solamente con clases ----------------
        public int idValidacion { get; set; }
        public string descripcionValidacion { get; set; }

        // ---------------- Se usa solamente con activos ----------------
        public string valor { get; set; }
    }
}