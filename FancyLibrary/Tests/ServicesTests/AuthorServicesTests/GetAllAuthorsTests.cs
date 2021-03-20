using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class GetAllAuthorsTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_get_all_authors")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);

            db.Authors.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsGettingAllAuthorsFromDatabase()
        {
            List<Author> actual = authorServices.GetAllAuthors();
            List<Author> expected = db.Authors.ToList();

            Assert.AreEqual(actual, expected);
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
