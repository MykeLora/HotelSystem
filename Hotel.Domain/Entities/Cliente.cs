﻿using Hotel.Domain.Core;
using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Entities
{
    public class Cliente : Person
    {
        [Key]
        public int IdCliente {  get; set; }
        public string? TipoDocumento {  get; set; }
        public string? Documento {  get; set; }
    }
}
