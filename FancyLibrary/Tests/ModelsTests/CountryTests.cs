using Data.Entities;
using NUnit.Framework;
using System;

namespace Tests.ModelsTests
{
    public class CountryTests
    {
        [Test]
        public void IsCountryNameThrowingExceptionWhenNull()
        {
            Country country = null;

            string expected = string.Format("Country name must be atleast {0} characters long!", 3);

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            country = new Country
            {
                Id = 1,
                Name = ""
            });

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsCountryNameThrowingExceptionWhenShorter()
        {
            Country country = null;

            string expected = string.Format("Country name must be atleast {0} characters long!", 3);

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            country = new Country
            {
                Id = 1,
                Name = "cn"
            });

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsCountryNameThrowingExceptionWhenWhiteSpace()
        {
            Country country = null;

            string expected = string.Format("Country name must be atleast {0} characters long!", 3);

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            country = new Country
            {
                Id = 1,
                Name = "       "
            });

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsSettingCountryNameCorectly()
        {
            Country country = new Country
            {
                Id = 1,
                Name = "Bulgaria"
            };

            Assert.That(country.Name, Is.EqualTo("Bulgaria"));
        }

        [Test]
        public void IsSettingCountryIdCorectly()
        {
            Country country = new Country
            {
                Id = 1,
                Name = "Bulgaria"
            };

            Assert.That(country.Id, Is.EqualTo(1));
        }
    }
}
