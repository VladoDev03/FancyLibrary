using ConsoleVersion.Models;
using ConsoleVersion.Services;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Tests.AddUserTests.UserBookServicesTests
{
    public class AddUserTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            users = CreateInMemoryDb();
        }

        [Test]
        public void IsControllerAddingUsers()
        {
            int currCount = users.Count;

            db.Users.AddRange(users);
            db.SaveChanges();

            userServices.AddUser(new User
            {
                Username = "programmer",
                Password = "Sa12$15",
                FirstName = "pro",
                LastName = "grammer",
                LogData = new LogData
                {
                    LastTimeLoggedIn = DateTime.Now,
                    RegisterDate = DateTime.Now,
                    TimesLoggedIn = 1,
                    IsOnline = true
                }
            });

            db.SaveChanges();

            Assert.That(currCount + 1, Is.EqualTo(db.Users.Count()));
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
