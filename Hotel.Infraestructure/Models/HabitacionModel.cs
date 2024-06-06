using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Models
{
    public class HabitacionModel
    {
        public int IdHabitacion { get; set; }
        public string? Numero { get; set; }
        public string? Detalle { get; set; }
        public decimal? Precio { get; set; }
        public  int? IdPiso {  get; set; }
        public int? IdCategoria {  get; set; }
        public string? Descripcion { get; set; }
        public string? DescripcionPiso { get; set; }
        public bool? EstadoPiso { get; set; }

    }
}
