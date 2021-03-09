using ConsoleVersion.Models;
using ConsoleVersion.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public class CountryServices : ICountryServices
    {
        private FancyLibraryContext db;

        public CountryServices(FancyLibraryContext db)
        {
            this.db = db;
        }

        public void AddCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
        }

        public Country FindCountry(string name)
        {
            Country country = db.Countries
                .FirstOrDefault(c => c.Name == name);

            return country;
        }

        public Country FindCountry(int id)
        {
            Country country = db.Countries
                .FirstOrDefault(c => c.Id == id);

            return country;
        }

        public List<Country> GetAllCountries()
        {
            return db.Countries.ToList();
        }
    }
}
