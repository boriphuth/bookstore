using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure.Repositories.Tests
{
    public class BaseTestClass
    {
        private readonly string connString = @"Data Source=(localdb)\v11.0;Initial Catalog=BookstoreTest;Integrated Security=True";
        
        protected BookstoreContext Context { get; private set; }

        [TestFixtureSetUp]
        protected void Init()
        {
            Database.SetInitializer<BookstoreContext>(new LocalDbContextInitializer());
            Context = new BookstoreContext(connString);
        }
    }
}
