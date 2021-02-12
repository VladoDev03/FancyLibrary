using ConsoleVersion.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UserTests
{
    public class UserTests
    {
        [Test]
        public void IsThrowingCorrectExceptionWhenShorterThanMinLength()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => 
                user = new User(
                "12",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                12,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false));

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenNullOrEmpty()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User(
                "",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                12,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false));

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenWideSpace()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User(
                "    ",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                12,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false));

            Assert.That(ae.Message, Is.EqualTo("Username must be atleast 3 characters long!"));
        }

        [Test]
        public void IsThrowingCorrectExceptionWhenAgeIsLessThanMinimum()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User(
                "vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                1,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false));

            Assert.That(ae.Message, Is.EqualTo("You have to be at least 7 years old!"));
        }

        [Test]
        public void SettingAgeWhenValueIsEqualToMinAge()
        {
            User user = new User("vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                7,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false);

            Assert.That(user.Age, Is.EqualTo(7));
        }

        [Test]
        public void SettingAgeWhenValueIsMoreThanMinAge()
        {
            User user = new User("vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                18,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false);

            Assert.That(user.Age, Is.EqualTo(18));
        }

        [Test]
        public void SettingAgeWhenValueIsOneMoreThanMinAge()
        {
            User user = new User("vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                8,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false);

            Assert.That(user.Age, Is.EqualTo(8));
        }

        [Test]
        public void SettingAgeWhenValueIsOneLessThanMinAge()
        {
            User user = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
                user = new User(
                "vlad111",
                "Salamur$12",
                "vlad",
                "vlado",
                "vladeto",
                6,
                DateTime.Parse("1010-10-10"),
                DateTime.Parse("2020-02-20"),
                false));

            Assert.That(ae.Message, Is.EqualTo("You have to be at least 7 years old!"));
        }
    }
}
