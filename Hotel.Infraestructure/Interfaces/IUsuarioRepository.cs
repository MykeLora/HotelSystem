using Hotel.Domain.Repository;
using Hotel.Infraestructure.Models;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        List<UsuarioModel> GetUsuarioByRol(int IdRolUsuario);
    }
}
