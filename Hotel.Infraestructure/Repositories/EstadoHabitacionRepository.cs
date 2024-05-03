using Hotel.Domain.Entities;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Repositories
{
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion>, IEstadoHabitacion
    {
        private readonly HotelContext context;
        private readonly ILogger<EstadoHabitacion> logger;

        public EstadoHabitacionRepository(HotelContext context, ILogger<EstadoHabitacion> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<EstadoHabitacion> GetEntities()
        {
            return base.GetEntities().Where(es => !es.Eliminado).ToList();
        }

        public override EstadoHabitacion GetEntity(int id)
        {
            var EstadoHab = this.context.EstadoHabitacion.Find(id);

            if (EstadoHab is not null)
            {
                return EstadoHab;
            }
            else
            {
                return null;
            }
        }

        public override void Save(EstadoHabitacion entity)
        {
            try
            {
                if(context.EstadoHabitacion.Any(es => es.Id == entity.Id))
                {
                    this.logger.LogWarning("Estado de la habitacion ocupado");
                }

                this.context.EstadoHabitacion.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error al registrar la categoria", ex.ToString());
            }
        }

        public override void Update(EstadoHabitacion entity)
        {
            try
            {
                var EstadoHabToUpdate = this.GetEntity(entity.Id);

                if(EstadoHabToUpdate is null)
                {
                    this.logger.LogWarning("La habitacion no está ocupada");
                }

                EstadoHabToUpdate.Estado = entity.Estado;
                EstadoHabToUpdate.IdUsuarioMod = EstadoHabToUpdate.IdUsuarioMod;
                EstadoHabToUpdate.FechaMod = entity.FechaMod;


                this.context.EstadoHabitacion.Update(EstadoHabToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Error al actualizar el estado de la habitación");
            }
        }

        public override void Remove(EstadoHabitacion entity)
        {
            try
            {
                EstadoHabitacion estadoHabToRemove = this.GetEntity(entity.Id);

                if(estadoHabToRemove is null)
                {
                    this.logger.LogWarning("El estado de la habitacion no está ocupado");
                }

                estadoHabToRemove.FechaElimino = entity.FechaElimino;
                estadoHabToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                estadoHabToRemove.Eliminado = true;

                this.context.EstadoHabitacion.Remove(estadoHabToRemove);
                this.context.SaveChanges();

            }
            catch (Exception)
            {

                this.logger.LogError("Error al eliminar el estado de la habitación");
            }
        }

        public override List<EstadoHabitacion> FindAll(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            return this.context.EstadoHabitacion.Where(filter).ToList();
        }

        public override bool Exists(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            return this.context.EstadoHabitacion.Any(filter);
        }
    }
}
