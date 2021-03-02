using System;
using System.Collections.Generic;
using System.Text;
using ConsoleVersion.Controllers;
using ConsoleVersion.Models;
using ConsoleVersion.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests.UserServicesTests
{
    public class GetFullNameTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;
        private UserController userController;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);
            userController = new UserController(userServices);

            users = CreateInMemoryDb();
        }

        [Test]
        public void ReturnTwoNamesIfMiddleIsNull()
        {
            var options = new DbContextOptionsBuilder<FancyLibraryContext>()
                .UseInMemoryDatabase(databaseName: "fancy_library")
                .Options;

            var db = new FancyLibraryContext(options);

            UserServices userServices = new UserServices(db);
            UserController userController = new UserController(userServices);

            List<User> users = CreateInMemoryDb();

            db.Users.AddRange(users);
            db.SaveChanges();

            userController.LoginUser(new List<string>() { "vladsto", "Salamur$12" });

            Assert.That(userController.GetFullName(), Is.EqualTo("Vladimir Stoyanov"));
        }

        [Test]
        public void ReturnThreeNumbersWhenMiddleNameIsNotNull()
        {
            var options = new DbContextOptionsBuilder<FancyLibraryContext>()
                .UseInMemoryDatabase(databaseName: "fancy_library")
                .Options;

            var db = new FancyLibraryContext(options);

            UserServices userServices = new UserServices(db);
            UserController userController = new UserController(userServices);

            List<User> users = CreateInMemoryDb();

            db.Users.AddRange(users);
            db.SaveChanges();

            userController.LoginUser(new List<string>() { "hammer", "Salamur$12" });

            Assert.That(userController.GetFullName(), Is.EqualTo("ham strong mer"));
        }

        public List<User> CreateInMemoryDb()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Username = "vladsto",
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
                    Username = "hammer",
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
                    Username = "sandwich",
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
                    Username = "telephone",
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
                    Username = "InMemory",
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
