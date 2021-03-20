using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.CountryServicesTests
{
    public class GetAllCountriesTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private CountryServices countryServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_countries")
                   .Options;

            db = new FancyLibraryContext(options);

            countryServices = new CountryServices(db);
        }

        [Test]
        public void IsGettingAllCountries()
        {
            db.Countries.AddRange(CreateInMemoryDb());
            db.SaveChanges();

            Assert.That(countryServices.GetAllCountries().Count, Is.EqualTo(db.Countries.Count()));
        }

        public List<Country> CreateInMemoryDb()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Name = "Bulgaria"
                },
                new Country
                {
                    Name = "USA"
                }
            };

            return countries;
        }
    }
}
