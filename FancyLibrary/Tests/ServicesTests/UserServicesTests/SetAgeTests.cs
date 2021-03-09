using Data.Entities;
using NUnit.Framework;
using Services;
using System;

namespace Tests.ServicesTests.UserServicesTests
{
    public class SetAgeTests
    {
        private UserServices userServices;
        private FancyLibraryContext db;

        [SetUp]
        public void Setup()
        {
            db = new FancyLibraryContext();
            userServices = new UserServices(db);
        }

        [Test]
        public void IsMethodSettingCorrectAge()
        {
            User user = new User
            {
                Username = "vladsto",
                Password = "P$rola12",
                FirstName = "vladko",
                LastName = "Sladko",
                Birthday = DateTime.Parse("2003-05-20")
            };

            userServices.SetAge(user);

            Assert.That(user.Age, Is.EqualTo(17));
        }
    }
}
