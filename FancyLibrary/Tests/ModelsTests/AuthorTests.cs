using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ModelsTests
{
    public class AuthorTests
    {
        [Test]
        public void IsSettingAuthorIdCorrectly()
        {
            Author author = new Author
            {
                Id = 1,
                FirstName = "firstName1",
                LastName = "lastName1"
            };

            Assert.That(author.Id, Is.EqualTo(1));
        }

        [Test]
        public void IsThrowingExceptionWhenFirstNameIsNull()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "",
                    MiddleName = "vlado",
                    LastName = "SomeName"
                });

            Assert.That(ae.Message, Is.EqualTo("First name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingExceptionWhenFirstNameIsWhiteSpace()
        {

            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "      ",
                    MiddleName = "vlado",
                    LastName = "SomeName"
                });

            Assert.That(ae.Message, Is.EqualTo("First name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingExceptionWhenFirstNameShorterThanMinimumLength()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "as",
                    MiddleName = "vlado",
                    LastName = "SomeName"
                });

            Assert.That(ae.Message, Is.EqualTo("First name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsSettingFirstNameWhenValueIsCorrect()
        {
            Author author = new Author
            {
                FirstName = "firstName1",
                LastName = "lastName2"
            };

            Assert.That(author.FirstName, Is.EqualTo("firstName1"));
        }

        [Test]
        public void IsThrowingExceptionWhenLastNameIsNull()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "SomeOtherName",
                    MiddleName = "vlado",
                    LastName = ""
                });

            Assert.That(ae.Message, Is.EqualTo("Last name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingExceptionWhenLastNameIsWhiteSpace()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "SomeName",
                    MiddleName = "vlado",
                    LastName = "     "
                });

            Assert.That(ae.Message, Is.EqualTo("Last name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingExceptionWhenLastNameShorterThanMinimumLength()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "Vladi",
                    MiddleName = "vlado",
                    LastName = "as"
                });

            Assert.That(ae.Message, Is.EqualTo("Last name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsSettingLastNameWhenValueIsCorrect()
        {
            Author author = new Author
            {
                FirstName = "firstName1",
                LastName = "lastName2"
            };

            Assert.That(author.LastName, Is.EqualTo("lastName2"));
        }

        [Test]
        public void IsMiddleNameThrowingExceptionWhenNotNullButShorter()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "vlad",
                    MiddleName = "a",
                    LastName = "vladeto",
                });

            Assert.That(ae.Message, Is.EqualTo("Middle name must be atleast 3 characters long!"));
        }

        [Test]
        public void NotThrowingExceptionWhenMiddleNameIsNull()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = null,
                LastName = "vladeto"
            };

            Assert.That(author.MiddleName, Is.EqualTo(null));
        }

        [Test]
        public void IsSettingMiddleNameWhenNotNull()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = "vlado",
                LastName = "vladeto"
            };

            Assert.That(author.MiddleName, Is.EqualTo("vlado"));
        }

        [Test]
        public void IsSettingBirthdayCorrectly()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = "vlado",
                LastName = "vladeto",
                Birthday = DateTime.Today
            };

            Assert.That(author.Birthday, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void IsNicknameThrowingExceptionWhenNotNullButShorter()
        {
            Author author = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                author = new Author
                {
                    FirstName = "vlad",
                    MiddleName = "glaaad",
                    LastName = "vladeto",
                    Nickname = "nn"
                });

            Assert.That(ae.Message, Is.EqualTo("Nickname must be atleast 3 characters long!"));
        }

        [Test]
        public void NotThrowingExceptionWhenNicknameIsNull()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = null,
                LastName = "vladeto",
                Nickname = null
            };

            Assert.That(author.Nickname, Is.EqualTo(null));
        }

        [Test]
        public void IsSettingNicknameCorrectly()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = "vlado",
                LastName = "vladeto",
                Nickname = "vlad111"
            };

            Assert.That(author.Nickname, Is.EqualTo("vlad111"));
        }

        [Test]
        public void IsSettingCountryIdCorrectly()
        {
            Author author = new Author
            {
                FirstName = "longFirstName",
                MiddleName = "vlado",
                LastName = "vladeto",
                CountryId = 1
            };

            Assert.That(author.CountryId, Is.EqualTo(1));
        }
    }
}
