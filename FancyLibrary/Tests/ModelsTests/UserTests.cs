using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ModelsTests
{
    public class UserTests
    {
        [Test]
        public void IsThrowingCorrectExceptionWhenShorterThanMinLength()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => 
                user = new User
                {
                    Username = "12",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenNullOrEmpty()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenWiteSpace()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "    ",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenAgeIsLessThanMinimum()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "vlad111",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 1
                });

            Assert.That(ae.Message, Is.EqualTo("You have to be at least 7 years old!"));
        }

        [Test]
        public void SettingAgeWhenValueIsEqualToMinAge()
        {
            User user = new User
            {
                Username = "vlad111",
                Password = "Salamur$12",
                FirstName = "vlad",
                MiddleName = "vlado",
                LastName = "vladeto",
                Age = 7
            };

            Assert.That(user.Age, Is.EqualTo(7));
        }

        [Test]
        public void SettingAgeWhenValueIsMoreThanMinAge()
        {
            User user = new User
            {
                Username = "vlad111",
                Password = "Salamur$12",
                FirstName = "vlad",
                MiddleName = "vlado",
                LastName = "vladeto",
                Age = 18
            };

            Assert.That(user.Age, Is.EqualTo(18));
        }

        [Test]
        public void SettingAgeWhenValueIsOneMoreThanMinAge()
        {
            User user = new User
            {
                Username = "vlad111",
                Password = "Salamur$12",
                FirstName = "vlad",
                MiddleName = "vlado",
                LastName = "vladeto",
                Age = 8
            };

            Assert.That(user.Age, Is.EqualTo(8));
        }

        [Test]
        public void SettingAgeWhenValueIsOneLessThanMinAge()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "vlad111",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 6
                });

            Assert.That(ae.Message, Is.EqualTo("You have to be at least 7 years old!"));
        }

        [Test]
        public void IsMiddleNameThrowingExceptionWhenNotNullButShorter()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "vlad111",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "a",
                    LastName = "vladeto",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Middle name must be atleast 3 characters long!"));
        }
    }
}
