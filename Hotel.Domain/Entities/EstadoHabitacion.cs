using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class EstadoHabitacion : BaseEntity
    {
        [Key]
        public int IdEstadoHabitacion {  get; set; }
    }
}
