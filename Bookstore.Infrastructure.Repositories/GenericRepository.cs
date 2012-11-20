using Bookstore.Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Bookstore.Domain.Entities;
using System.Data;

namespace Bookstore.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IRepositoryContext Context { get; set; }
        protected readonly IDbSet<T> entities;

        protected GenericRepository(IRepositoryContext context)
        {
            this.Context = context;
            this.entities = context.Set<T>();
        }

        public T Create(T entity)
        {
            return entities.Add(entity);
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }
            entities.Remove(entity);
        }

        public void Update(T entity)
        {
            var entry = Context.Entry(entity);
            entities.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public T FindById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> FindAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<T> FindByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
