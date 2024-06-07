using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Models.Category
{
    public class CategoryGetModel : BaseModel
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }

    }
}
