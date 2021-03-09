using ConsoleVersion.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class CountryController
    {
        private ICountryServices countryServices;

        public CountryController(ICountryServices countryServices)
        {
            this.countryServices = countryServices;
        }
    }
}
