using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public  class Habitacion : BaseEntity
    {
         public string? Numero {  get; set; }
         public string? Detalle {  get; set; }
         public  decimal? Precio {  get; set; }
         
         public string? IdEstadoHabitacion {  get; set; }
         public int? IdPiso {  get; set; }
         public int? IdCategoria {  get; set; }
    }
}
