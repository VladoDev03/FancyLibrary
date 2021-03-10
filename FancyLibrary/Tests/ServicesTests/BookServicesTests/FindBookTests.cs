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
    public class FindBookTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_book")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Books.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void FindCorrectBookByGivenTitle()
        {
            Book result = bookServices.FindBook("title1");

            Assert.AreEqual("title1", result.Title);
        }

        [Test]
        public void FindCorrectBookByGivenId()
        {
            Book result = bookServices.FindBook(2);

            Assert.AreEqual("title2", result.Title);
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
