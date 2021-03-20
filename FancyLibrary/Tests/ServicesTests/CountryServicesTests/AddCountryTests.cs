using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace Tests.ServicesTests.CountryServicesTests
{
    public class AddCountryTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private CountryServices countryServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_add_country")
                   .Options;

            db = new FancyLibraryContext(options);

            countryServices = new CountryServices(db);

            db.Countries.AddRange(CreateInMemoryDb());
            db.SaveChanges();
        }

        [Test]
        public void IsAddingCountryToDatabase()
        {
            Country country = new Country
            {
                Name = "Russia"
            };

            countryServices.AddCountry(country);
            bool result = countryServices.GetAllCountries().Exists(c => c.Name == "Russia");

            Assert.IsTrue(result);
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
