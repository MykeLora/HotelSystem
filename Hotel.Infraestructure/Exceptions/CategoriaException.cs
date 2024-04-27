using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Exceptions
{
    public class CategoriaException : Exception
    {
        public CategoriaException()
            : base("Ocurrió un error relacionado con las categorías.")
        {
        }

        public CategoriaException(string message) : base(message)
        {

        }

        public CategoriaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public int? CategoriaId {  get; set; }
        public string categoriaId { get; set; }
    }
}
