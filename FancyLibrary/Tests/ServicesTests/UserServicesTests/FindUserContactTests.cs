using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.UserServicesTests
{
    public class FindUserContactTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_contact")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            users = CreateInMemoryDb();
            db.Users.AddRange(users);
            db.Contacts.AddRange(CreateInMemoryDb1());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsFindingCorrectContactWhenUserExists()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            Contact contact = userServices.FindUserContact(user);
            bool result = contact.Email == "vlado@dev.git" && contact.Phone == "1234567890";

            Assert.IsTrue(result);
        }

        [Test]
        public void IsReturningNullWhenUserIsNull()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "null:)");

            Contact contact = userServices.FindUserContact(user);
            bool result = contact == null;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsReturningNullWhenUserHasNoContact()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "hammer");

            Contact contact = userServices.FindUserContact(user);
            bool result = contact == null;

            Assert.IsTrue(result);
        }

        public List<User> CreateInMemoryDb()
        {
            List<User> users = new List<User>
            {
                new User
                {
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
                        IsOnline = true,
                    }
                },

                new User
                {
                    UserName = "hammer",
                    Password = "42)snncmfT",
                    FirstName = "ham",
                    MiddleName = "strong",
                    LastName = "mer",
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
                    UserName = "sandwich",
                    Password = "42)snncmfT",
                    FirstName = "sand",
                    LastName = "wich",
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
                    UserName = "telephone",
                    Password = "42)snncmfT",
                    FirstName = "tele",
                    LastName = "phone",
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
                    UserName = "InMemory",
                    Password = "42)snncmfT",
                    FirstName = "In1",
                    LastName = "Memeory",
                    LogData = new LogData
                    {
                        LastTimeLoggedIn = DateTime.Now,
                        RegisterDate = DateTime.Now,
                        TimesLoggedIn = 1,
                        IsOnline = true
                    }
                }
            };

            return users;
        }

        private List<Contact> CreateInMemoryDb1()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Email = "vlado@dev.git",
                    Phone = "1234567890"
                }
            };

            return contacts;
        }
    }
}
