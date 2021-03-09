using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Services.Contracts
{
    public interface ICountryServices
    {
        void AddCountry(Country country);

        List<Country> GetAllCountries();

        Country FindCountry(string name);

        Country FindCountry(int id);
    }
}
