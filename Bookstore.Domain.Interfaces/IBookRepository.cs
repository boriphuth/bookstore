using Bookstore.Domain.Entities;
using System.Collections.Generic;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> FindByAuthorId(int id);
    }
}
