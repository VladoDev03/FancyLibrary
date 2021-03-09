using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.UserServicesTests
{
    public class LogDataChangeTests
    {

        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;
        private User user;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_change_log_data")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            users = CreateInMemoryDb();
            db.Users.AddRange(users);
            db.SaveChanges();

            user = users.FirstOrDefault();
        }

        [Test]
        public void IsIncreasingLogTimesWithOne()
        {
            userServices.IncreaseLogInCount(user);

            Assert.That(user.LogData.TimesLoggedIn, Is.EqualTo(2));
        }

        [Test]
        public void IsChangingLastLogInTimeCorrectly()
        {
            userServices.ChangeLastLogIn(user);

            string actual = user.LogData.LastTimeLoggedIn.ToLongTimeString();
            string expected = DateTime.Now.ToLongTimeString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IsChangingStatusFromOnlineToOffline()
        {
            userServices.ChangeStatus(user);

            Assert.That(user.LogData.IsOnline, Is.EqualTo(false));
        }

        [Test]
        public void IsChangingStatusFromOfflineToOnline()
        {
            userServices.ChangeStatus(user);
            userServices.ChangeStatus(user);

            Assert.That(user.LogData.IsOnline, Is.EqualTo(true));
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
