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
    public class GetBookSavedTimesTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_times_saved_book")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.UsersBooks.AddRange(CreateInMemoryDb1());
            db.Books.AddRange(CreateInMemoryDb2());
            db.SaveChanges();
        }

        [Test]
        public void IsFindingCorrectSavedTimesOfBook()
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == 1);

            int n = bookServices.GetBookSavedTimes(book);

            Assert.AreEqual(1, n);
        }

        public List<UserBook> CreateInMemoryDb1()
        {
            List<UserBook> userBook = new List<UserBook>
            {
                new UserBook
                {
                    UserId = 1,
                    BookId = 1
                },
                new UserBook
                {
                    UserId = 2,
                    BookId = 2
                }
            };

            return userBook;
        }

        public List<Book> CreateInMemoryDb2()
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
