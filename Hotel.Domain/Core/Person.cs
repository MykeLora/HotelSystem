using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Core
{
    public abstract class Person : BaseEntity
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
    }
}
