using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface ICountryServices
    {
        void AddCountry(Country country);

        List<Country> GetAllCountries();

        Country FindCountry(string name);

        Country FindCountry(int id);
    }
}
