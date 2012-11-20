using Bookstore.Domain.Entities;
using System.Collections.Generic;

namespace Bookstore.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> FindByLastName(string name);
    }
}
