using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;

namespace Tests.ServicesTests.CountryServicesTests
{
    public class FindCountryTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private CountryServices countryServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_country")
                   .Options;

            db = new FancyLibraryContext(options);

            countryServices = new CountryServices(db);
        }

        [Test]
        public void IsFindingCountryByName()
        {
            db.Countries.AddRange(CreateInMemoryDb1());
            db.SaveChanges();

            Country actual = countryServices.FindCountry("USA");

            Country expected = new Country
            {
                Name = "USA"
            };

            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [Test]
        public void IsFindingCountryById()
        {
            db.Countries.AddRange(CreateInMemoryDb2());
            db.SaveChanges();

            Country actual = countryServices.FindCountry(3);

            Country expected = new Country
            {
                Id = 3,
                Name = "Russia"
            };

            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        public List<Country> CreateInMemoryDb1()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "USA"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bulgaria"
                }
            };

            return countries;
        }

        public List<Country> CreateInMemoryDb2()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Id = 3,
                    Name = "Russia"
                },
                new Country
                {
                    Id = 4,
                    Name = "China"
                }
            };

            return countries;
        }
    }
}
