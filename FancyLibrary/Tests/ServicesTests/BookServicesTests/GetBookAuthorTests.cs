using Data.Entities;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ServicesTests.BookServicesTests
{
    public class GetBookAuthorTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_book_author_name")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Authors.AddRange(CreateInMemoryDb1());
            db.Books.AddRange(CreateInMemoryDb2());
            db.SaveChanges();
        }

        [Test]
        public void IsFindingCorrectSavedTimesOfBook()
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == 1);
            Author author = bookServices.GetBookAuthor(book);

            string name = "firstName1 lastName1";
            string result = NameRefactorer
                .GetFullName(author.FirstName, author.MiddleName, author.LastName);

            Assert.AreEqual(name, result);
        }

        public List<Author> CreateInMemoryDb1()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "firstName1",
                    LastName = "lastName1"
                },
                new Author
                {
                    Id = 2,
                    FirstName = "firstName2",
                    LastName = "lastName2"
                }
            };

            return authors;
        }

        public List<Book> CreateInMemoryDb2()
        {
            List<Book> authors = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    AuthorId = 2
                }
            };

            return authors;
        }
    }
}
