using Bookstore.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Bookstore.Infrastructure.Repositories.Tests
{
    class LocalDbContextInitializer : DropCreateDatabaseAlways<BookstoreContext>
    {
        protected override void Seed(BookstoreContext context)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person 
                {
                    FirstName="John", LastName="Tolkien",
                    Books = new List<Book> 
                    {
                        new Book { Title = "The Fellowship of the Ring", ISBN = "0-618-57494-8" },
                        new Book { Title = "The Two Towers" },
                        new Book { Title = "The Return of the King", ISBN = "0-345-33973-8" }
                    }
                },
                new Person 
                {
                    FirstName="George", LastName="Martin",
                    Books = new List<Book> 
                    {
                        new Book { Title = "A Game of Thrones", ISBN = "0-553-10354-7" }
                    }
                },
                new Person 
                {
                    FirstName="Carl", LastName="Sagan",
                    Books = new List<Book> 
                    {
                        new Book { Title = "Contact", ISBN="0-671-43400-4"}
                    }
                },
                new Person 
                {
                    FirstName="Douglas", LastName="Adams",
                    Books = new List<Book> 
                    {
                        new Book { Title = "The Hitchhiker's Guide to the Galaxy", ISBN = "0-330-25864-8"}
                    }
                },
                new Person 
                {
                    FirstName="Eduardo", LastName="Spohr",
                    Books = new List<Book> 
                    {
                        new Book { Title = "A Batalha do Apocalipse", ISBN = "978-85-7686-076-1" }
                    }
                },
                new Person 
                {
                    FirstName="Stephenie", LastName="Meyer",
                    Books = new List<Book> 
                    {
                        new Book { Title = "Twilight", ISBN = "0-316-16017-2" },
                        new Book { Title = "New Moon", ISBN = "0-316-16019-9" },
                        new Book { Title = "Eclipse", ISBN = "978-0-316-16020-9" },
                    }
                },
            };

            foreach (var item in persons)
            {
                context.Persons.Add(item);
            }
            context.SaveChanges();
        }
    }
}