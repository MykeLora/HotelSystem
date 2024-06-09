﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Models
{
    public class PisoModel 
    {
        public int Id { get; set; } 
        public string? Descripcion { get; set; }
        public bool? Estado {  get; set; }
        public DateTime FechaCreacion { get; }
    }
}
