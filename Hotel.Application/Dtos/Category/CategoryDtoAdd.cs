using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dtos.Category
{
    public class CategoryDtoAdd : CategoryDtoBase
    {
        public bool? Estado { get; internal set; }
        public DateTime FechaCreacion { get; internal set; }
    }
}
