using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dtos.Category
{
    public class CategoryDtoRemove
    {
        public int IdCategoria { get; set; }
        public int IdUsuarioElimino {  get; set; }
        public DateTime FechaElimino { get; set; }
    }
}
