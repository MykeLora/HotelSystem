using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string? NombreCompleto { get; set; }
        public string? Correo {  get; set; }
        public string? Clave {  get; set; }
        public int? IdRolUsuario {  get; set; }

    }
}
