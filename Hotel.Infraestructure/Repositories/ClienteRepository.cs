using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<Cliente> logger;

        public ClienteRepository(HotelContext context, ILogger<Cliente> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Cliente> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override Cliente GetEntity(int id)
        {
            var cliente = this.context.Cliente.Find(id);

            if(cliente is not null)
            {
                return cliente;
            }
            else
            {
                return null;
            }
        }

        public override void Save(Cliente entity)
        {
           
            try
            {
                if(this.context.Cliente.Any(c => c.IdCliente == entity.IdCliente))
                {
                    this.logger.LogWarning("El cliente ya se encuentra registrado");
                }

                this.context.Cliente.Add(entity);
                this.context.SaveChanges();


            }catch(Exception ex)
            {
                this.logger.LogError("Error al registrar el cliente", ex.ToString());
            }
        }

        public override void Update(Cliente entity)
        {
            try
            {
                var clienteToUpdate = this.GetEntity(entity.IdCliente);

                if(clienteToUpdate is  null) 
                {
                    this.logger.LogError("El cliente no existe");
                }

                clienteToUpdate.Correo = clienteToUpdate.Correo;
                clienteToUpdate.Documento = clienteToUpdate.Documento;
                clienteToUpdate.NombreCompleto = clienteToUpdate.NombreCompleto;
                clienteToUpdate.IdUsuarioMod = clienteToUpdate.IdUsuarioMod;
                clienteToUpdate.FechaMod = entity.FechaMod;

                this.context.Cliente.Update(clienteToUpdate);
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al actualizar el cliente");

            }
        }

        public override void Remove(Cliente entity)
        {
            try
            {
                Cliente clienteToRemove = this.GetEntity(entity.IdCliente);

                if(clienteToRemove is null)
                {
                    this.logger.LogWarning("El cliente no existe");
                }

                clienteToRemove.FechaElimino = entity.FechaElimino;
                clienteToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                clienteToRemove.Eliminado = true;

                this.context.Cliente.Remove(clienteToRemove);
                this.context.SaveChanges();


            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al eliminar el cliente",ex.ToString());

            }
        }

        public override bool Exists(Expression<Func<Cliente, bool>> filter)
        {
            return this.context.Cliente.Any(filter);
        }

        public override List<Cliente> FindAll(Expression<Func<Cliente, bool>> filter)
        {
            return this.context.Cliente.Where(filter).ToList();
        }
    }
}
