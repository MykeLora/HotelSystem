using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Habitacion> Habitacion {  get; set; }
        public DbSet<Piso> Piso { get; set; }   
        public DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }

    }
}
