using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class AddAuthorTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_add_author")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);

            db.Authors.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsGettingAllAuthorsFromDatabase()
        {
            Author author = new Author
            {
                Id = 3,
                FirstName = "FirstName3",
                LastName = "LastName3"
            };

            authorServices.AddAuthor(author);

            bool result = authorServices
                .GetAllAuthors()
                .Exists(a => a.Id == author.Id);

            Assert.IsTrue(result);
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
