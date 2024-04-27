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
    public class CategoryRepository : BaseRepository<Categoria>, ICategoryRepository
    {
        private readonly HotelContext context;
        private readonly ILogger<Categoria> logger;

        public CategoryRepository(HotelContext context, ILogger<Categoria> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Save(Categoria entity)
        {
            try
            {
                if(context.Categoria.Any(C => C.Id == entity.Id))
                {
                    this.logger.LogWarning("La categoria ya se encuentra registrada");
                }

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

                //if(categoryToUpdate == null)
                //{
                //    throw new 
                //}

                categoryToUpdate.Descripcion = categoryToUpdate.Descripcion;
                categoryToUpdate.IdUsuarioMod = categoryToUpdate.IdUsuarioMod;
                categoryToUpdate.FechaMod = entity.FechaMod;
                categoryToUpdate.EsActivo = entity.EsActivo;

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

        public override bool Exists(Expression<Func<Categoria, bool>> filter)
        {
            return base.Exists(filter);
        }

        public override void Remove(Categoria entity)
        {
            base.Remove(entity);
        }

    }
}
