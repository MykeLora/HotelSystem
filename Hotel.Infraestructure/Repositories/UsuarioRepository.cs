using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Models;
using Microsoft.Extensions.Logging;
using Northwind.Domain.Entities;
using System.Linq.Expressions;

namespace Hotel.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<Usuario> logger;

        public UsuarioRepository(HotelContext context, ILogger<Usuario> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }


        public List<UsuarioModel> GetUsuarioByRol(int IdRolUsuario)
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            try
            {
               var usuario = (from user in this.context.Usuario
                           join rolUser in this.context.RolUsuario on user.Id equals rolUser.Id
                           where user.IdRolUsuario == IdRolUsuario
                           select new UsuarioModel()
                           {
                               Descripcion = rolUser.Descripcion,
                               Estado = rolUser.Estado,
                               Nombre = user.NombreCompleto,
                               Correo = user.Correo
                           }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al obtener la información: " + ex.Message);
            }

            return usuarios;
        }

        public override List<Usuario> GetEntities()
        {
            return base.GetEntities().Where(us => !us.Eliminado).ToList();
        }

        public override Usuario GetEntity(int id)
        {
            var usuario = this.context.Usuario.Find(id);

            if(usuario is not null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public override void Save(Usuario entity)
        {
            try
            {
                if(this.context.Usuario.Any(us => us.Id == entity.Id))
                {
                    this.logger.LogWarning("El usuario ya se encuentra registrado");
                }

                this.context.Usuario.Add(entity);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al registrar el usuario", ex.ToString());

            }
        }

        public override void Update(Usuario entity)
        {
            try
            {
                var usuarioToUpdate = this.GetEntity(entity.Id);

                if (usuarioToUpdate is null)
                {
                    this.logger.LogError("El cliente no existe");
                }

                usuarioToUpdate.Clave = usuarioToUpdate.Clave;
                usuarioToUpdate.Correo = usuarioToUpdate.Correo;
                usuarioToUpdate.NombreCompleto = usuarioToUpdate.NombreCompleto;
                usuarioToUpdate.IdRolUsuario = usuarioToUpdate.IdRolUsuario;
                usuarioToUpdate.IdUsuarioMod = usuarioToUpdate.IdUsuarioMod;
                usuarioToUpdate.FechaMod = entity.FechaMod;

                this.context.Usuario.Update(usuarioToUpdate);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al actualizar el usuario");
            }
      
        }

        public override void Remove(Usuario entity)
        {

            try
            {
                Usuario usuarioToRemove = this.GetEntity(entity.Id);

                if (usuarioToRemove is null)
                {
                    this.logger.LogError("El usuario no existe");
                }

                usuarioToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                usuarioToRemove.FechaElimino = entity.FechaElimino;
                usuarioToRemove.Eliminado = true;

                this.context.Usuario.Remove(usuarioToRemove);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Ha ocurrido un error al eliminar el usuario");
            }
        
        }

        public override bool Exists(Expression<Func<Usuario, bool>> filter)
        {
            return this.context.Usuario.Any(filter);
        }

        public override List<Usuario> FindAll(Expression<Func<Usuario, bool>> filter)
        {
            return this.context.Usuario.Where(filter).ToList();
        }

    
    }
}
