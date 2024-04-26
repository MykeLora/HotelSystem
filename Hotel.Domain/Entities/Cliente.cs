using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string? TipoDocumento {  get; set; }
        public string? Documento {  get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get;set }
    }
}
