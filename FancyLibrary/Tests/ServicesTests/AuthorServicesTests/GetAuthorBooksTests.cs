using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class GetAuthorBooksTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_get_author_books")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);
        }

        [Test]
        public void IsGettingAllAuthorsFromDatabase()
        {
            db.Authors.AddRange(FillAuthors());
            db.Books.AddRange(FillBooks());
            db.SaveChanges();

            Author author = new Author
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1"
            };

            List<Book> expected = new List<Book>
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
                    AuthorId = 1
                }
            };

            List<Book> result = authorServices
                .GetAuthorBooks(author);

            Assert.AreEqual(expected.Count, result.Count);
        }

        [Test]
        public void IsReturningCorrectBookCount()
        {
            Author author = db.Authors
                .FirstOrDefault(a => a.Id == 2);

            int n = authorServices.GetAuthorBooksCount(author);

            Assert.AreEqual(1, authorServices.GetAuthorBooksCount(author));
        }

        public List<Author> FillAuthors()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1"
                },
                new Author
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2"
                }
            };

            return authors;
        }

        public List<Book> FillBooks()
        {
            List<Book> books = new List<Book>
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
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "title3",
                    Genre = "genre3",
                    AuthorId = 2
                }
            };

            return books;
        }
    }
}
