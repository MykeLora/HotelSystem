using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            FechaRegistro = DateTime.Now;
            Estado = true;
        }

        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
    }
}
