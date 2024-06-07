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
    public class RolUsuarioRepository : BaseRepository<RolUsuario>, IRolUsuarioRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<RolUsuario> logger;

        public RolUsuarioRepository(HotelContext context, ILogger<RolUsuario> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<RolUsuario> GetEntities()
        {
            return base.GetEntities().Where(ro => !ro.Eliminado).ToList();
        }

        public override RolUsuario GetEntity(int id)
        {
            var rolUser = this.context.RolUsuario.Find(id);

            if(rolUser is not null)
            {
                return rolUser;
            }
            else
            {
                return null;
            }
        }

        public override void Save(RolUsuario entity)
        {
            try
            {
                if(this.context.RolUsuario.Any(ro => ro.IdRolUsuario == entity.IdRolUsuario))
                {
                    this.logger.LogWarning("El rol del usuario ya se encuentra registrado");
                }

                this.context.RolUsuario.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                this.logger.LogError("Errol al registrar el rolUsuario");
            }
        }

        public override void Update(RolUsuario entity)
        {
            try
            {
                var roluserToUpdate = this.GetEntity(entity.IdRolUsuario);

                if(roluserToUpdate is null)
                {
                    this.logger.LogError("El cliente no existe");
                }

                roluserToUpdate.Descripcion = roluserToUpdate.Descripcion;
                roluserToUpdate.Estado = roluserToUpdate.Estado;
                roluserToUpdate.IdUsuarioMod = roluserToUpdate.IdUsuarioMod;
                roluserToUpdate.FechaMod = entity.FechaMod;

                this.context.RolUsuario.Update(roluserToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar el rol del usuario");
            }
        }

        public override void Remove(RolUsuario entity)
        {
            try
            {
                RolUsuario rolUsuarioToRemove = this.GetEntity(entity.IdRolUsuario);

                if (rolUsuarioToRemove is null)
                {
                    this.logger.LogError("El rol de usuario no existe");
                }

                rolUsuarioToRemove.FechaElimino = entity.FechaElimino;
                rolUsuarioToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                rolUsuarioToRemove.Eliminado = true;

                this.context.RolUsuario.Remove(rolUsuarioToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al eliminar el rol del usuario");
            }
        


        }

        public override bool Exists(Expression<Func<RolUsuario, bool>> filter)
        {
            return this.context.RolUsuario.Any(filter);
        }

        public override List<RolUsuario> FindAll(Expression<Func<RolUsuario, bool>> filter)
        {
            return this.context.RolUsuario.Where(filter).ToList();
        }
    }
}
