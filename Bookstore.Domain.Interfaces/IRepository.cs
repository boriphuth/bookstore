using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bookstore.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByFilter(Expression<Func<T, bool>> predicate);        
    }
}
