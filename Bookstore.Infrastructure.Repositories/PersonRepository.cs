using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Bookstore.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(BookstoreContext context)
            : base(context)
        {
        }

        public IEnumerable<Person> FindByLastName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
