using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Entities
{
    public class Piso : BaseEntity
    {
        public string? Descripcion {  get; set; }
        public bool? Estado { get; set; }
    }
}
