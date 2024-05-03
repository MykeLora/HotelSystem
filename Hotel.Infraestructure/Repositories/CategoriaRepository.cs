using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Core;
using Hotel.Infraestructure.Exceptions;
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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoryRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<Categoria> logger;

        public CategoriaRepository(HotelContext context, ILogger<Categoria> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Categoria> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Save(Categoria entity)
        {
            try
            {
                if(context.Categoria.Any(C => C.Id == entity.Id))
                {
                    this.logger.LogWarning("La categoria ya se encuentra registrada");
                }

                context.Categoria.Add(entity);
                context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al registrar la categoria", ex.ToString());
            }
        }

        public override void Update(Categoria entity)
        {
            try
            {
                var categoryToUpdate = this.GetEntity(entity.Id);

                if (categoryToUpdate == null)
                {
                    throw new CategoriaException("La categoria no existe");
                }

                categoryToUpdate.Descripcion = categoryToUpdate.Descripcion;
                categoryToUpdate.IdUsuarioMod = categoryToUpdate.IdUsuarioMod;
                categoryToUpdate.FechaMod = entity.FechaMod;
                categoryToUpdate.Estado= entity.Estado;

                this.context.Categoria.Update(categoryToUpdate);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Error al actualizar la categoria", ex.ToString());
            }
        }

        public override Categoria GetEntity(int id)
        {
            var categoria = this.context.Categoria.Find(id);

            if(categoria != null)
            {
                return categoria;
            }
            else
            {
                return null;
            }


        }

        public override void Remove(Categoria entity)
        {
            try
            {
                Categoria categoriaToRemove = this.GetEntity(entity.Id);

                if(categoriaToRemove is null)
                
                    throw new CategoriaException("La Categoria no existe.");

                categoriaToRemove.FechaElimino = entity.FechaElimino;
                categoriaToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;
                categoriaToRemove.Eliminado = true;

                this.context.Categoria.Update(categoriaToRemove);
                this.context.SaveChanges();
                

            }
            catch(Exception ex)
            {
                this.logger.LogError("", ex.ToString());

            }
        }

        public override bool Exists(Expression<Func<Categoria, bool>> filter)
        {
            return this.context.Categoria.Any(filter);
        }

        public override List<Categoria> FindAll(Expression<Func<Categoria, bool>> filter)
        {
            return this.context.Categoria.Where(filter).ToList();
        }

    }
}
