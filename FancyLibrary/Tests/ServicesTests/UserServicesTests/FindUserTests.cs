using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;

namespace Tests.ServicesTests.UserServicesTests
{
    public class FindUserTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_find_user")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            users = CreateInMemoryDb();
            db.Users.AddRange(users);
            db.SaveChanges();
        }

        [Test]
        public void IsFindingCorrectUserByUserName()
        {
            User user = userServices.FindUser("vladsto");

            Assert.That(user.UserName, Is.EqualTo("vladsto"));
        }

        [Test]
        public void IsFindingCorrectUserById()
        {
            User user = userServices.FindUser(1);

            Assert.That(user.UserName, Is.EqualTo("vladsto"));
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
    }
}
