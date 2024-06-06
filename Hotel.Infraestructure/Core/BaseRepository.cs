using Hotel.Domain.Repository;
using Hotel.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infraestructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private DbSet<TEntity> entities;

        public BaseRepository(HotelContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return entities.Where(entity => entity != null).ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            
            return this.entities.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
            this.context.SaveChanges();

        }

    }
}
