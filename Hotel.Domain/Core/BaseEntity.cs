using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.FechaCreacion = DateTime.Now;
            this.Estado = true;
            this.Eliminado = false;
        }

        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
        public bool? Estado { get; set; }
    }
}
