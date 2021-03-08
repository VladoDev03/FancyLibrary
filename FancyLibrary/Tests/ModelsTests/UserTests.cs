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
        public void IsThrowingCorrectExceptionWhenUsernameShorterThanMinLength()
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
        public void IsThrowingCorrectExceptionWhenUsernameNullOrEmpty()
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
        public void IsThrowingCorrectExceptionWhenUsernameWiteSpace()
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

        [Test]
        public void IsSettingMiddleNameWhenNotNull()
        {
            User user = new User
            {
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "longFirstName",
                MiddleName = "vlado",
                LastName = "vladeto",
                Age = 12
            };

            Assert.That(user.MiddleName, Is.EqualTo("vlado"));
        }

        [Test]
        public void NotThrowingExceptionWhenMiddleNameIsNull()
        {
            User user = new User
            {
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "longFirstName",
                MiddleName = null,
                LastName = "vladeto",
                Age = 12
            };

            Assert.That(user.MiddleName, Is.EqualTo(null));
        }

        [Test]
        public void ThrowingCorrectExceptionWhenBirthdayIsNull()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "vlad111",
                    Password = "Salamur$12",
                    FirstName = "vlad",
                    MiddleName = "aaaa",
                    LastName = "vladeto",
                    Birthday = default,
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("You have to give us your birthday date so we know how old you are!"));
        }

        [Test]
        public void SettingBirthdayCorrectWhenValueIsValid()
        {
            User user = new User
            {
                Username = "vlad111",
                Password = "Salamur$12",
                FirstName = "vlad",
                MiddleName = "aaaa",
                LastName = "vladeto",
                Birthday = DateTime.Parse("2003-05-20"),
                Age = 12
            };
                
            Assert.That(user.Birthday, Is.EqualTo(DateTime.Parse("2003-05-20")));
        }

        [Test]
        public void IsFirstNameThrowingExceptionWhenNull()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "LongUsername",
                    Password = "Salamur$12",
                    FirstName = "",
                    MiddleName = "vlado",
                    LastName = "SomeName",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("First name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsFirstNameThrowingExceptionWhenShorter()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "LongUsername",
                    Password = "Salamur$12",
                    FirstName = "sh",
                    MiddleName = "vlado",
                    LastName = "vladeto",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("First name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsLastNameThrowingExceptionWhenNull()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "LongUsername",
                    Password = "Salamur$12",
                    FirstName = "LongName",
                    MiddleName = "vlado",
                    LastName = "",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Last name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsLastNameThrowingExceptionWhenShorter()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User
                {
                    Username = "LongUsername",
                    Password = "Salamur$12",
                    FirstName = "shoooo",
                    MiddleName = "vlado",
                    LastName = "a",
                    Age = 12
                });

            Assert.That(ae.Message, Is.EqualTo("Last name must be atleast 3 characters long!"));
        }

        [Test]
        public void IsToStringReturningCorrectInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {1}");
            sb.AppendLine($"Username - LongUsername");
            sb.AppendLine($"Password - Salamur$12");
            sb.AppendLine($"First name - shoooo");
            sb.AppendLine($"Middle name - vlado");
            sb.AppendLine($"Last name - aaaa");
            sb.AppendLine($"Age - 12");

            string correct = sb.ToString().Trim();

            User user = user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12
            };

            Assert.That(user.ToString(), Is.EqualTo(correct));
        }

        [Test]
        public void IsSettingContactIdWhenNotNull()
        {
            User user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12,
                ContactId = 1
            };

            Assert.That(user.ContactId, Is.EqualTo(1));
        }

        [Test]
        public void IsSettingContactIdToNullWhenValueIsNull()
        {
            User user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12,
                ContactId = null
            };

            Assert.That(user.ContactId, Is.EqualTo(null));
        }

        [Test]
        public void IsSettingLogDataIdWhenNotNull()
        {
            User user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12,
                LogDataId = 1
            };

            Assert.That(user.LogDataId, Is.EqualTo(1));
        }

        [Test]
        public void IsSettingCountryIdWhenNotNull()
        {
            User user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12,
                CountryId = 1
            };

            Assert.That(user.CountryId, Is.EqualTo(1));
        }

        [Test]
        public void IsSettingCountryIdToNullWhenValueIsNull()
        {
            User user = new User
            {
                Id = 1,
                Username = "LongUsername",
                Password = "Salamur$12",
                FirstName = "shoooo",
                MiddleName = "vlado",
                LastName = "aaaa",
                Age = 12,
                CountryId = null
            };

            Assert.That(user.CountryId, Is.EqualTo(null));
        }
    }
}
