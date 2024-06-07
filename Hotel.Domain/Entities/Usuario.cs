using Hotel.Domain.Core;
using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Entities
{
    public class Usuario : Person
    {
        [Key]
        public int IdUsuario {  get; set; }
        public string? Clave {  get; set; }
        public int? IdRolUsuario {  get; set; }

    }
}
