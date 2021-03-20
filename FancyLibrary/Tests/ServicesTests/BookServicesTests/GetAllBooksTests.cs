using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.BookServicesTests
{
    public class GetAllBooksTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_get_all_books")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Books.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsGettingAllBooksFromDatabase()
        {
            List<Book> actual = bookServices.GetAllBooks();
            List<Book> expected = db.Books.ToList();

            Assert.AreEqual(actual, expected);
        }

        public List<Book> CreateInMemoryDb()
        {
            List<Book> authors = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1"
                },
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2"
                }
            };

            return authors;
        }
    }
}
