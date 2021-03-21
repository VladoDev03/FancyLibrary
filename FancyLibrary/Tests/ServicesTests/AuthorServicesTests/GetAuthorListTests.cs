using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class GetAuthorListTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_list_author_data")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);

            db.Authors.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsFindingCorrectInfoAboutAllAuthors()
        {
            List<Author> authors = authorServices.GetAllAuthors();

            List<AuthorView> authorsViews = authorServices.GetAuthorList(authors);
            List<AuthorView> expected = new List<AuthorView>
            {
                new AuthorView
                {
                    Id = 1,
                    FullName = "Author One First",
                    BooksCount = 1,
                    Country = "Bulgaria"
                },
                new AuthorView
                {
                    Id = 2,
                    FullName = "Authors two second",
                    BooksCount = 3,
                    Country = null
                }
        };

            Assert.AreEqual(expected.Count, authorsViews.Count);
        }

        public List<Author> CreateInMemoryDb()
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
    }
}
