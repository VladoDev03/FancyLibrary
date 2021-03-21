using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace Tests.ServicesTests.BookServicesTests
{
    public class GetBookListTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_book_info")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Books.AddRange(CreateInMemoryDb());
            db.Authors.AddRange(CreateInMemoryDb1());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsFindingCorrectInfoAboutAllBooks()
        {
            List<Book> books = bookServices.GetAllBooks();

            List<BookView> booksViews = bookServices.GetBookList(books);
            List<BookView> expected = new List<BookView>
            {
                new BookView
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    Year = 100,
                    SavedTimes = 0,
                    AuthorName = "uno dos tres"
                },
                new BookView
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    Year = 200,
                    SavedTimes = 0,
                    AuthorName = "ain cvain drain"
                }
            };

            Assert.AreEqual(expected.Count, booksViews.Count);
        }

        public List<Book> CreateInMemoryDb()
        {
            List<Book> authors = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    Year = 100,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    Year = 200,
                    AuthorId = 2
                }
            };

            return authors;
        }

        public List<Author> CreateInMemoryDb1()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "uno",
                    MiddleName = "dos",
                    LastName = "tres"
                },
                new Author
                {
                    Id = 2,
                    FirstName = "ain",
                    MiddleName = "cvain",
                    LastName = "drain"
                }
            };

            return authors;
        }
    }
}
