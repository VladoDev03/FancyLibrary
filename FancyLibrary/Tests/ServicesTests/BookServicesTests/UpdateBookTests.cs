using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.BookServicesTests
{
    public class UpdateBookTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private BookServices bookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_update_book")
                   .Options;

            db = new FancyLibraryContext(options);

            bookServices = new BookServices(db);

            db.Books.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsChangingTitleCorrectly()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = "titleNew",
                Genre = book.Genre,
                Pages = book.Pages,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual("titleNew", book.Title);
        }

        [Test]
        public void IsChangingGenreCorrectly()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = "GenreNew",
                Pages = book.Pages,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual("GenreNew", book.Genre);
        }

        [Test]
        public void IsChangingPagesCorrectly()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Pages = 101,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual(101, book.Pages);
        }

        [Test]
        public void IsChangingYearCorrectly()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Pages = book.Pages,
                Year = 2021
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual(2021, book.Year);
        }

        [Test]
        public void NotChangingTitleWhenNewValueIsNull()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = null,
                Genre = book.Genre,
                Pages = book.Pages,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual("title1", book.Title);
        }

        [Test]
        public void NotChangingTitleWhenNewValueIsEqualToOldValue()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = "title1",
                Genre = book.Genre,
                Pages = book.Pages,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual("title1", book.Title);
        }

        [Test]
        public void NotChangingGenreWhenNewValueIsEqualToOldValue()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = "genre1",
                Pages = book.Pages,
                Year = book.Year
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual("genre1", book.Genre);
        }

        [Test]
        public void NotChangingPagesWhenNewValueIsEqualToOldValue()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Pages = book.Pages,
                Year = 2020
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual(2020, book.Year);
        }

        [Test]
        public void NotChangingYearWhenNewValueIsEqualToOldValue()
        {
            Book book = db.Books.FirstOrDefault();
            EditBookDTO editBookDTO = new EditBookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Pages = book.Pages,
                Year = 2021
            };

            bookServices.UpdateBook(editBookDTO);

            Assert.AreEqual(100, book.Pages);
        }

        public List<Book> CreateInMemoryDb()
        {
            List<Book> authors = new List<Book>
            {
                new Book
                {
                    Title = "title1",
                    Genre = "genre1",
                    Pages = 100,
                    Year = 2020
                },
                new Book
                {
                    Title = "title2",
                    Genre = "genre2",
                    Pages = 100,
                    Year = 2020
                }
            };

            return authors;
        }
    }
}
