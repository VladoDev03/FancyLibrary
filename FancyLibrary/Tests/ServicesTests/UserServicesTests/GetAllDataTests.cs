using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Entities;
using Services;
using Data.ViewModels;
using System.Linq;

namespace Tests.ServicesTests.UserServicesTests
{
    public class GetAllDataTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_get_user_data")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            db.Users.AddRange(CreateInMemoryDb());
            db.Contacts.AddRange(FillContacts());

            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsGettingCorrectDataAboutUsers()
        {
            User user = db.Users.FirstOrDefault(u => u.Id == 1);

            FullUserView view = userServices.GetAllData(user);

            Assert.AreEqual(view.Username, "vladsto");
            Assert.AreEqual(view.FirstName, "Vladimir");
            Assert.AreEqual(view.MiddleName, "Empty");
            Assert.AreEqual(view.LastName, "Stoyanov");
            Assert.AreEqual(view.BooksCount, 0);
            Assert.AreEqual(view.Email, "vlado@dev.git");
            Assert.AreEqual(view.Phone, "0123456789");
        }

        [Test]
        public void IsNullWhenUsersIsNull()
        {
            User user = null;

            FullUserView view = userServices.GetAllData(user);

            Assert.AreEqual(view, null);
        }

        [Test]
        public void IsGettingCorrectDataAboutUsersWhenUserHasContactsWithNullValues()
        {
            User user = db.Users.FirstOrDefault(u => u.Id == 2);

            FullUserView view = userServices.GetAllData(user);

            Assert.AreEqual(view.Username, "vladsto1");
            Assert.AreEqual(view.FirstName, "Vladimir1");
            Assert.AreEqual(view.MiddleName, "Empty");
            Assert.AreEqual(view.LastName, "Stoyanov1");
            Assert.AreEqual(view.BooksCount, 0);
            Assert.AreEqual(view.Email, "Empty");
            Assert.AreEqual(view.Phone, "Empty");
        }

        [Test]
        public void IsGettingCorrectDataAboutUsersWhenUserHasNoContacts()
        {
            User user = db.Users.FirstOrDefault(u => u.Id == 3);

            FullUserView view = userServices.GetAllData(user);

            Assert.AreEqual(view.Username, "vladsto2");
            Assert.AreEqual(view.FirstName, "Vladimir2");
            Assert.AreEqual(view.MiddleName, "Empty");
            Assert.AreEqual(view.LastName, "Stoyanov2");
            Assert.AreEqual(view.BooksCount, 0);
            Assert.AreEqual(view.Email, "Empty");
            Assert.AreEqual(view.Phone, "Empty");
        }

        public List<User> CreateInMemoryDb()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserName = "vladsto",
                    Password = "42)snncmfT",
                    FirstName = "Vladimir",
                    LastName = "Stoyanov",
                    ContactId = 1,
                    LogData = new LogData
                    {
                        LastTimeLoggedIn = DateTime.Now,
                        RegisterDate = DateTime.Now,
                        TimesLoggedIn = 1,
                        IsOnline = true
                    }
                },
                new User
                {
                    Id = 2,
                    UserName = "vladsto1",
                    Password = "42)snncmfT1",
                    FirstName = "Vladimir1",
                    LastName = "Stoyanov1",
                    ContactId = 2,
                    LogData = new LogData
                    {
                        LastTimeLoggedIn = DateTime.Now,
                        RegisterDate = DateTime.Now,
                        TimesLoggedIn = 1,
                        IsOnline = true
                    }
                },
                new User
                {
                    Id = 3,
                    UserName = "vladsto2",
                    Password = "42)snncmfT2",
                    FirstName = "Vladimir2",
                    LastName = "Stoyanov2",
                    LogData = new LogData
                    {
                        LastTimeLoggedIn = DateTime.Now,
                        RegisterDate = DateTime.Now,
                        TimesLoggedIn = 1,
                        IsOnline = true
                    }
                },
            };

            return users;
        }

        public List<Contact> FillContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Email = "vlado@dev.git",
                    Phone = "0123456789"
                },
                new Contact
                {
                    Id = 2
                }
            };

            return contacts;
        }
    }
}
