using ConsoleVersion.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UtilsTests.PasswordManagerTests
{
    public class IsPasswordValidTests
    {
        [Test]
        public void ThrowsCorrectExceptionWhenPasswordIsShorter()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => PasswordManager.IsPasswordValid("Sa$1"));

            Assert.That(ae.Message, Is.EqualTo("Password must be atleast 7 characters long!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessUpperCaseLetters()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => PasswordManager.IsPasswordValid("salamur$12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 upper case letter!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessLowerCaseLetters()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => PasswordManager.IsPasswordValid("SALAMUR$12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 lower case letter!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessDigits()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => PasswordManager.IsPasswordValid("Salamur$"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 digit!"));
        }

        [Test]
        public void ThrowsCorrectExceptionWhenPasswordHasLessSymbols()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => PasswordManager.IsPasswordValid("Salamur12"));

            Assert.That(ae.Message, Is.EqualTo("Password must contain at least 1 symbol!"));
        }

        [Test]
        public void IsSettingPasswordWhenEverythingIsCorrect()
        {
            bool result = PasswordManager.IsPasswordValid("Salamur$12");
            Assert.IsTrue(result);
        }
    }
}
