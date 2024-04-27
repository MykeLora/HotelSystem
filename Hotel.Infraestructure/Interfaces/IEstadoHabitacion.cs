using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IEstadoHabitacion : IBaseRepository<EstadoHabitacion>
    {
    }
}
