using Services.Contracts;

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
