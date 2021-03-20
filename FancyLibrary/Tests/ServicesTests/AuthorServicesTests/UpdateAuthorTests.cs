using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.AuthorServicesTests
{
    public class UpdateAuthorTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private AuthorServices authorServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_change_first_name")
                   .Options;

            db = new FancyLibraryContext(options);

            authorServices = new AuthorServices(db);

            db.Authors.AddRange(CreateInMemoryDb());
            db.Countries.AddRange(CreateInMemoryDb1());
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db.Database.EnsureDeleted();
        }

        [Test]
        public void IsChangingFirstNameCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = "FirsteName1",
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("FirsteName1", author.FirstName);
        }

        [Test]
        public void IsChangingMiddleNameCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = "MidleName1",
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("MidleName1", author.MiddleName);
        }

        [Test]
        public void IsChangingLastNameCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = "LasteName1",
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("LasteName1", author.LastName);
        }

        [Test]
        public void IsChangingNicknameCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = "Nikename",
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("Nikename", author.Nickname);
        }

        [Test]
        public void IsChangingBirthdayCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = DateTime.Parse("1212-12-12"),
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(DateTime.Parse("1212-12-12"), author.Birthday);
        }

        [Test]
        public void IsChangingCountryCorrectly()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = "USA"
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("USA", author.Country.Name);
        }

        [Test]
        public void NotChangingAuthorFirstNameWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = null,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(author.FirstName, "FirstName1");
        }

        [Test]
        public void NotChangingAuthorCountryNameWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = null
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual("Bulgaria", author.Country.Name);
        }

        [Test]
        public void NotChangingAuthorMiddleNameWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = null,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(author.MiddleName, "MiddleName1");
        }

        [Test]
        public void NotChangingAuthorLastNameWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = null,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(author.LastName, "LastName1");
        }

        [Test]
        public void NotChangingAuthorNicknameWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = null,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(author.Nickname, "Nickname1");
        }

        [Test]
        public void NotChangingAuthorBirthdayWhenNewValueIsNull()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = null,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(DateTime.Parse("20-12-20"), author.Birthday);
        }

        [Test]
        public void NotChangingAuthorBirthdayWhenNewValueIsEqualToOldValue()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = DateTime.Parse("20-12-20"),
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(DateTime.Parse("20-12-20"), author.Birthday);
        }

        [Test]
        public void NotChangingAuthorFirstNameWhenNewValueIsEqualToOldValue()
        {
            Author author = db.Authors.FirstOrDefault();
            EditAuthorDTO editAuthorDTO = new EditAuthorDTO
            {
                Id = author.Id,
                FirstName = "FirstName1",
                MiddleName = author.MiddleName,
                LastName = author.LastName,
                Birthday = author.Birthday,
                Nickname = author.Nickname,
                Country = db.Countries.FirstOrDefault().Name
            };

            authorServices.UpdateAuthor(editAuthorDTO);

            Assert.AreEqual(author.FirstName, "FirstName1");
        }

        public List<Author> CreateInMemoryDb()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    MiddleName = "MiddleName1",
                    LastName = "LastName1",
                    Birthday = DateTime.Parse("2020-12-20"),
                    Nickname = "Nickname1",
                    CountryId = 1
                },
                new Author
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    MiddleName = "MiddleName2",
                    LastName = "LastName2",
                    Birthday = DateTime.Parse("2020-12-20"),
                    Nickname = "Nickname2",
                    CountryId = 1
                }
            };

            return authors;
        }

        public List<Country> CreateInMemoryDb1()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria"
                }
            };

            return countries;
        }
    }
}
