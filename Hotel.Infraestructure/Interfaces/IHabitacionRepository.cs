using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        List<HabitacionModel> GetHabitacionByCategoria(int categoriaId);

        List<HabitacionModel> GetHabitacionsByPisoId(int IdPiso);
    }
}
