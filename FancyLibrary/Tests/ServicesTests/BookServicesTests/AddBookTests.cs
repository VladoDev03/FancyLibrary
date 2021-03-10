using Data.Entities;
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
    public class AddBookTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_add_book")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Books.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsAddingCorrectBookToDatabase()
        {
            Book book = new Book
            {
                Id = 3,
                Title = "title3",
                Genre = "genre3"
            };

            bookServices.AddBook(book);

            bool result = bookServices
                .GetAllBooks()
                .Exists(b => b.Id == book.Id);

            Assert.IsTrue(result);
        }

        public List<Book> CreateInMemoryDb()
        {
            List<Book> authors = new List<Book>
            {
                new Book
                {
                    Title = "title1",
                    Genre = "genre1"
                },
                new Book
                {
                    Title = "title2",
                    Genre = "genre2"
                }
            };

            return authors;
        }
    }
}
