﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Models
{
    public class UsuarioModel
    {
        public int IdRolUsuario { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado {  get; set; }
        public int IdUsuario { get; set; }
        public string? Nombre {  get; set; }
        public  string? Correo {  get; set; }

            
    }
}
