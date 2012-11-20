using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookstoreContext : DbContext, IRepositoryContext, IUnitOfWork
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Person> Persons { get; set; }

        public BookstoreContext()
            : base()
        {
        }

        public BookstoreContext(string connString)
            : base(connString)
        {
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
