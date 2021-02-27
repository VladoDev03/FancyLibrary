using ConsoleVersion.Models;
using ConsoleVersion.Services;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AddUserTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsControllerAddingUsers()
        {
            var options = new DbContextOptionsBuilder<FancyLibraryContext>()
                .UseInMemoryDatabase(databaseName: "fancy_library")
                .Options;

            var db = new FancyLibraryContext(options);

            UserServices userServices = new UserServices(db);

            List<User> users = CreateInMemoryDb();
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
                    Password = "Sa12$15",
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
                    Password = "Sa12$15",
                    FirstName = "ham",
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
                    Password = "Sa12$15",
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
                    Password = "Sa12$15",
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
                    Password = "Sa12$15",
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
