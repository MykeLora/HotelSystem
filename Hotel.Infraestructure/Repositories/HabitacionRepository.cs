using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Models;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<HabitacionModel> logger;

        public HabitacionRepository(HotelContext context, ILogger<HabitacionModel> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }


        public List<HabitacionModel> GetHabitacionByCategoria(int categoriaId)
        {
            List<HabitacionModel> habitacions = new List<HabitacionModel>();

            try
            {
                habitacions = (from hab in this.context.Habitacion
                               join ca in this.context.Categoria on hab.IdCategoria equals ca.IdCategoria
                               join pi in this.context.Piso on hab.IdPiso equals pi.IdPiso
                               where hab.IdCategoria == categoriaId
                               select new HabitacionModel()
                               {
                                   Descripcion = ca.Descripcion,
                                   Detalle = hab.Detalle,
                                   Precio = hab.Precio,
                                   Numero = hab.Numero,
                                   DescripcionPiso = pi.Descripcion,
                                   EstadoPiso = pi.Estado

                               }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo las habitaciones por su categoria."+ ex.ToString());
            }

            return habitacions;
        }

        public override List<Habitacion> GetEntities()
        {
            return base.GetEntities().Where(h => !h.Eliminado).ToList();
        }

        public override Habitacion GetEntity(int id)
        {
            var habitacion = this.context.Habitacion.Find(id);

            if(habitacion is not null)
            {
                return habitacion;
            }
            else
            {
                return null;
            }
        }

        public override void Save(Habitacion entity)
        {
            try
            {
                if (context.Habitacion.Any(h => h.IdHabitacion == entity.IdHabitacion))
                {
                    this.logger.LogWarning("Ya existe una habitacion con ese id");
                }

                this.context.Habitacion.Add(entity);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error agregar la habitacion ", ex.ToString());
            }

        }

        public override void Update(Habitacion entity)
        {
            try
            {

                var HabitacionToUpdate = this.GetEntity(entity.IdHabitacion);

                if (HabitacionToUpdate == null)
                {
                    this.logger.LogWarning("La habitacion no existe");
                }

                HabitacionToUpdate.Detalle = entity.Detalle;
                HabitacionToUpdate.Precio = entity.Precio;
                HabitacionToUpdate.Numero = entity.Numero;
                HabitacionToUpdate.IdCategoria = entity.IdCategoria;
                HabitacionToUpdate.IdEstadoHabitacion = entity.IdEstadoHabitacion;
                HabitacionToUpdate.FechaMod = entity.FechaMod;
                HabitacionToUpdate.IdUsuarioMod = entity.IdUsuarioMod;

                this.context.Habitacion.Update(HabitacionToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar la habitacion", ex.ToString());
            }
        }

        public override void Remove(Habitacion entity)
        {
            try
            {
                Habitacion habitacionToRemove = this.GetEntity(entity.IdHabitacion);

                if (habitacionToRemove is  null)
                {
                    this.logger.LogError("La habitacion no existe");

                }

                habitacionToRemove.IdUsuarioElimino = habitacionToRemove.IdUsuarioElimino;
                habitacionToRemove.FechaElimino = entity.FechaElimino;
                habitacionToRemove.Eliminado = true;

                this.context.Habitacion.Remove(habitacionToRemove);
                this.context.SaveChanges(); 
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al intentar eliminar la habitacion");
            }
        }

        public override List<Habitacion> FindAll(Expression<Func<Habitacion, bool>> filter)
        {
            return this.context.Habitacion.Where(filter).ToList();
        }

        public override bool Exists(Expression<Func<Habitacion, bool>> filter)
        {
            return this.context.Habitacion.Any(filter);
        }

    }

}
