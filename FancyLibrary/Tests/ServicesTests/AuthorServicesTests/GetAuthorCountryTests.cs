using Data.Entities;
using Data.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class GetAuthorCountryTests
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

            db.Authors.AddRange(CreateInMemoryDbAuthors());
            db.Countries.AddRange(CreateInMemoryDbCountries());
            db.SaveChanges();
        }

        [Test]
        public void IsFindingCorrectCountryWhenCountryIdIsNotNull()
        {
            Author author = db.Authors.FirstOrDefault(a => a.FirstName == "Ivan");
            string countryName = authorServices.GetAuthorCountry(author);

            Assert.AreEqual("Bulgaria", countryName);
        }

        [Test]
        public void IsReturningUnknownWhenCountryIdIsNull()
        {
            Author author = db.Authors.FirstOrDefault(a => a.Id == 2);
            string countryName = authorServices.GetAuthorCountry(author);

            Assert.AreEqual("Unknown", countryName);
        }

        public List<Author> CreateInMemoryDbAuthors()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    FirstName = "Ivan",
                    LastName = "Vazov",
                    CountryId = 1
                },
                new Author
                {
                    FirstName = "Nekav",
                    LastName = "Avtor"
                }
            };

            return authors;
        }

        public List<Country> CreateInMemoryDbCountries()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Name = "Bulgaria"
                }
            };

            return countries;
        }
    }
}
