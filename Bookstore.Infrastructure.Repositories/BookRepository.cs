using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext context)
            : base(context)
        {
        }

        public IEnumerable<Book> FindByAuthorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
