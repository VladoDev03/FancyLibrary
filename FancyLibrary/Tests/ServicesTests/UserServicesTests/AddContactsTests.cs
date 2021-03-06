﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.UserServicesTests
{
    public class AddContactsTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserServices userServices;
        private List<User> users;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_add_contact")
                   .Options;

            db = new FancyLibraryContext(options);

            userServices = new UserServices(db);

            users = CreateInMemoryDb();
            db.Users.AddRange(users);
            db.Contacts.AddRange(FillContacts());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsSettingEmailCorrectly()
        {
            User user = db.Users.FirstOrDefault();

            userServices.AddEmail(user, "emaill@some.email");

            Assert.That(user.Contact.Email, Is.EqualTo("emaill@some.email"));
        }

        [Test]
        public void IsSettingPhoneCorrectly()
        {
            User user = db.Users.FirstOrDefault();

            userServices.AddPhone(user, "0123456789");

            Assert.That(user.Contact.Phone, Is.EqualTo("0123456789"));
        }

        [Test]
        public void IsAddingContactWhenContactIsValid()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            userServices.AddContact(user, "vlado@dev.git", "0123456789");
            bool result = user.Contact.Email == "vlado@dev.git" && user.Contact.Phone == "0123456789";

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNotAddingContactWhenEmailIsTaken()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            userServices.AddContact(user, "afqawf@segesg.aef", "2527957388"));

            Assert.AreEqual("This email is already taken!", ae.Message);
        }

        [Test]
        public void IsNotAddingContactWhenPhoneTaken()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            userServices.AddContact(user, "vlado@dev.git", "2527957388"));

            Assert.AreEqual("This phone is already taken!", ae.Message);
        }

        [Test]
        public void IsNotSettingContactWhenEmailIsEqualToOldEmail()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            userServices.AddContact(user, "vladodot@dev.git", "9573880962");

            Assert.AreEqual(user.Contact.Email, user.Contact.Email);
        }

        [Test]
        public void IsNotSettingContactWhenPhoneIsEqualToOldPhone()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            userServices.AddContact(user, "vladodot@dev.git", "9573880962");

            Assert.AreEqual(user.Contact.Phone, user.Contact.Phone);
        }

        [Test]
        public void IsNotSettingContactWhenEmailIsNull()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            userServices.AddContact(user, null, "9573880962");

            Assert.AreEqual(user.Contact.Email, user.Contact.Email);
        }

        [Test]
        public void IsNotSettingContactWhenPhoneIsNull()
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == "vladsto");

            userServices.AddContact(user, "vladodot@dev.git", null);

            Assert.AreEqual(user.Contact.Phone, user.Contact.Phone);
        }

        private List<User> CreateInMemoryDb()
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

        private List<Contact> FillContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 2,
                    Email = "afqawf@segesg.aef",
                    Phone = "2527957388"
                }
            };

            return contacts;
        }
    }
}
