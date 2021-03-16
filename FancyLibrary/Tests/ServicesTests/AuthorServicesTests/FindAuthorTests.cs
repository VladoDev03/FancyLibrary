using Data.Entities;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class FindAuthorTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_author")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);

            db.Authors.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsFindingCorrectAuthorByName()
        {
            Author author = authorServices.FindAuthor("FirstName1 LastName1");

            Assert.AreEqual(1, author.Id);
        }

        [Test]
        public void IsFindingCorrectAuthorById()
        {
            Author author = authorServices.FindAuthor(1);

            string fullName = NameRefactorer
                .GetFullName(author.FirstName, author.MiddleName, author.LastName);

            Assert.AreEqual("FirstName1 LastName1", fullName);
            //Assert.IsNotNull(author);
        }

        [Test]
        public void IsFindingCorrectAuthorByNullableId()
        {
            int? id = 1;

            Author author = authorServices.FindAuthor(id);

            string fullName = NameRefactorer
                .GetFullName(author.FirstName, author.MiddleName, author.LastName);

            Assert.AreEqual("FirstName1 LastName1", fullName);
            //Assert.IsNotNull(author);
        }

        public List<Author> CreateInMemoryDb()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1"
                },
                new Author
                {
                    FirstName = "FirstName2",
                    LastName = "LastName2"
                }
            };

            return authors;
        }
    }
}
