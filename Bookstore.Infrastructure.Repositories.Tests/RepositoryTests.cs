using Bookstore.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories.Tests
{
    [TestFixture]
    public class RepositoryTests : BaseTestClass
    {
        [Test]
        public void PersonsShouldReturnData()
        {
            var repo = new PersonRepository(Context);
            var data = repo.FindAll();
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }

        [Test]
        public void BooksShouldReturnData()
        {
            var repo = new BookRepository(Context);
            var data = repo.FindAll();
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }

        [Test]
        public void BooksCountShouldMatch()
        {
            var repo = new BookRepository(Context);
            var data = repo.FindAll();
            Assert.That(data.Count() == 10, "expected --> 10 got --> " + data.Count().ToString());
        }

        [Test]
        public void ShouldFindPersonById()
        {
            var repo = new PersonRepository(Context);
            var data = repo.FindById(1);
            Assert.That(data != null, "Unable to find person with id = 1.");
        }

        [Test]
        public void ShouldInsertBook()
        {
            var repo = new BookRepository(Context);
            var book = new Book { Title = "The Silmarillion", ISBN = "0-04-823139-8", AuthorId = 1 };
            repo.Create(book);
            Context.Commit();

            var savedBook = repo.FindAll().SingleOrDefault(x => x.Title == book.Title && x.ISBN == book.ISBN);
            Assert.That(savedBook != null, "Unable to find the book that was inserted.");
        }

        [Test]
        public void ShouldUpdateBook()
        {
            var repo = new BookRepository(Context);

            var book = repo.FindById(2); // The Two Towers
            book.ISBN = "9780618002238";
            repo.Update(book);
            Context.Commit();

            var updatedBook = repo.FindById(2);
            Assert.That(updatedBook.ISBN == book.ISBN, "The book property has not changed.");
        }

        [Test]
        public void ShouldDeleteAuthorWithBooks()
        {
            var personRepo = new PersonRepository(Context);

            var author = personRepo.FindById(6); // Stephenie Meyer
            personRepo.Delete(author);
            Context.Commit();

            var deletedAuthor = personRepo.FindById(6);
            Assert.That(deletedAuthor == null, "The deleted person was found by the repository.");

            var bookRepo = new BookRepository(Context);
            var deletedBooks = bookRepo.FindAll().Where(x => x.Id >= 8);

            Assert.That(!deletedBooks.Any(), "The person was deleted, but some of her books wasn't.");
        }

    }
}
